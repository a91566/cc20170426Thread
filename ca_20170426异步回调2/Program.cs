using System;
using System.Threading;

//http://www.cnblogs.com/lvcy/archive/2012/06/15/2550061.html

namespace ca_20170426异步回调2
{
	class Program
	{
		private static bool _isDone;

		static void Main(string[] args)
		{
			#region 异步回调
			Func<int, int, int> dl = TakeAWhile;
			dl.BeginInvoke(1, 3000, TakesAWhileCompleted, dl);
			while (_isDone == false)
			{
				Console.Write(".");
				Thread.Sleep(50);
			}
			#endregion

			Console.ReadKey();
		}

		static int TakeAWhile(int data, int ms)
		{
			Console.Write("TakesAWhile started");
			Thread.Sleep(ms);
			Console.WriteLine("TakeAWhile Completed");
			return ++data;
		}

		static void TakesAWhileCompleted(IAsyncResult ar)
		{
			if (ar == null)
				throw new ArgumentNullException("ar");
			Func<int, int, int> dl = (Func<int, int, int>)ar.AsyncState;
			int result = dl.EndInvoke(ar);
			Console.WriteLine("Result:{0}", result);
			_isDone = true;
		}
	}
}
