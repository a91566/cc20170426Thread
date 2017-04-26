using System;
using System.Threading;

namespace ca_20170426多线程回调
{
	class Program
	{
		static void Main(string[] args)
		{
			#region 异步执行
			Func<int, int, int> d2 = TakeAWhile;
			IAsyncResult ar = d2.BeginInvoke(1, 3000, null, null);
			while (!ar.IsCompleted)
			{
				Console.Write(".");
				Thread.Sleep(50);
			}
			int result = d2.EndInvoke(ar);
			Console.Write("result:{0}", result);
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
	}
}
