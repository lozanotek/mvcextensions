using System;
using System.Reflection;
using NVelocity;
using NVelocity.Runtime;
using NVelocity.Util.Introspection;

namespace MvcContrib.ViewEngines
{
	public class ExtensionDuck : IDuck
	{
		private readonly object _instance;
		private readonly Type _instanceType;
		private readonly Type[] _extensionTypes;
		private Introspector _introspector;

		public ExtensionDuck(object instance)
			: this(instance, Type.EmptyTypes)
		{
		}

		public ExtensionDuck(object instance, params Type[] extensionTypes)
		{
			if(instance == null) throw new ArgumentNullException("instance");

			_instance = instance;
			_instanceType = _instance.GetType();
			_extensionTypes = extensionTypes;
		}

		public Introspector Introspector
		{
			get
			{
				if(_introspector == null)
				{
					_introspector = RuntimeSingleton.Introspector;
				}
				return _introspector;
			}
			set { _introspector = value; }
		}

		public object GetInvoke(string propName)
		{
			throw new NotSupportedException();
		}

		public void SetInvoke(string propName, object value)
		{
			throw new NotSupportedException();
		}

		public object Invoke(string method, params object[] args)
		{
			if(string.IsNullOrEmpty(method)) return null;

			MethodInfo methodInfo = Introspector.GetMethod(_instanceType, method, args);
			if(methodInfo != null)
			{
				return methodInfo.Invoke(_instance, args);
			}

			var extensionArgs = new object[args.Length + 1];
			extensionArgs[0] = _instance;
			Array.Copy(args, 0, extensionArgs, 1, args.Length);

			foreach(var extensionType in _extensionTypes)
			{
				methodInfo = Introspector.GetMethod(extensionType, method, extensionArgs);
				if(methodInfo != null)
				{
					return InvokerHelper(methodInfo, null, extensionArgs);
				}
			}

			return null;
		}

		private object InvokerHelper(MethodInfo method, object instance, object[] args)
		{
			object returnVal = method.Invoke(instance, args);

			//some extension methods will have a void return type because they render directly to response.output
			//in this case we should return an empty string
			if(IsVoidMethod(method))
				return returnVal ?? string.Empty;

			return returnVal;      	   
		}

		private bool IsVoidMethod(MethodInfo method)
		{
			return method.ReturnType.Name.Equals("Void", StringComparison.Ordinal);
		}
	}
}