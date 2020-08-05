using MusicStore.Core.Entities;

namespace MusicStore.Core.Utilities
{
	public class OperationResult<T>
	{
		private OperationResult()
		{

		}

		public bool IsSuccess { get; private set; }
		public T Result { get; private set; }
		public string Message { get; private set; }

		public static OperationResult<T> CreateSuccessResult()
		{
			return new OperationResult<T>
			{
				IsSuccess = true
			};
		}

		public static OperationResult<T> CreateSuccessResult(T result)
		{
			return new OperationResult<T>()
			{
				Result = result,
				IsSuccess = true
			};
		}

		public static OperationResult<T> CreateNonSuccessResult(string message)
		{
			return new OperationResult<T>()
			{
				Message = message,
				IsSuccess = false
			};
		}
	}
}
