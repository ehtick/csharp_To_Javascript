using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public struct Type_0<T0, T1>
{
    public bool Prop_0 { get; set; }
}

public interface Type_1
{
    Type_1 Prop_0 { get; set; }

    Type_4 Prop_2 { get; set; }

    Type_4 Prop_3 { get; set; }

    abstract Type_2 Method_1(bool p0);
}

public interface Type_2
{
    int Prop_0 { get; set; }

    abstract bool Method_1(Type_2 p0, bool p1);
}

public class Type_3<T0>
{
    public static Type_3<string> Prop_0 { get; set; }
    public string Prop_1 { get; set; }
    public static Type_1 Prop_2 { get; set; }

    public Type_0<string, int> Method_3(int p0, Type_3<string> p1, bool p2)
    {
        for (int i0 = 0; i0 < 2; i0++)
        {
            try
            {
                Type_4 v1 = default(Type_4);
                string v2 = "c3b4235c";
                return new Type_0<string, int>()
                {
                    Prop_0 = p2
                };
            }
            catch (NullReferenceException ex3)
            {
                for (int i4 = 0; i4 < 3; i4++)
                {
                    Type_1 v5 = default(Type_1);
                    return this.Method_3(90, p1, false);
                }

                return new Type_0<string, int>();
            }

            Type_0<string, int> v6 = new Type_0<string, int>();
            return new Type_0<string, int>();
        }

        bool v7 = true;
        Type_4 v8 = default(Type_4);
        string v9 = "04998539";
        string v10 = this.Prop_1;
        return new Type_0<string, int>();
    }
}

public interface Type_4
{
    Type_1 Prop_1 { get; set; }

    Type_0<string, bool> Prop_2 { get; set; }

    abstract string Method_0(Type_2 p0, int p1, Type_4 p2);
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        Console.WriteLine("Trace");
        string v0 = "9396f9f7";
        for (int i1 = 0; i1 < 4; i1++)
        {
            Type_2 v2 = default(Type_2);
            for (int i3 = 0; i3 < 2; i3++)
            {
                i3 = i3;
            }

            for (int i4 = 0; i4 < 3; i4++)
            {
                try
                {
                    v2 = v2;
                    string v5 = await System.Threading.Tasks.Task.FromResult("1244422f");
                }
                catch (NullReferenceException ex6)
                {
                    string v7 = "d25c56fb";
                }

                Type_3<bool> v8 = new Type_3<bool>();
            }
        }

        v0 = "bc34cacc";
        await System.Threading.Tasks.Task.CompletedTask;
        Console.WriteLine(v0);
        if (false)
        {
            Console.WriteLine("Trace 9");
        }
        else
        {
            Console.WriteLine(v0);
            if (await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(false)))
            {
                await System.Threading.Tasks.Task.CompletedTask;
                if (("0ffca5c9") == (await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult("e3944e3d"))))
                {
                    Console.WriteLine("Trace 9");
                    Type_0<int, int> v9 = new Type_0<int, int>();
                    bool v10 = await System.Threading.Tasks.Task.FromResult(false);
                }
                else
                {
                    Type_1 v11 = default(Type_1);
                    Console.WriteLine("Trace 12");
                }
            }

            await System.Threading.Tasks.Task.CompletedTask;
        }

        await System.Threading.Tasks.Task.CompletedTask;
        Type_4 v12 = default(Type_4);
        try
        {
            for (int i13 = 0; i13 < 3; i13++)
            {
                for (int i14 = 0; i14 < 4; i14++)
                {
                    Type_3<string> v15 = new Type_3<string>();
                }
            }
        }
        catch (ArgumentException ex16)
        {
            Console.WriteLine(v0);
        }

        Console.WriteLine("Program End");
    }
}