using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public interface Type_0
{
    abstract int Method_0(string p0);
}

public struct Type_1
{
    public static int Prop_1 { get; set; }

    public static int Method_0(int p0)
    {
        p0 = (13) * (Type_1.Prop_1);
        for (int i0 = 0; i0 < 3; i0++)
        {
            for (int i1 = 0; i1 < 3; i1++)
            {
                i0 = 0;
                return 62;
            }

            for (int i2 = 0; i2 < 4; i2++)
            {
                Type_1 v3 = new Type_1();
                return 11;
            }

            return 33;
        }

        string v4 = "dab216db";
        if (true)
        {
            v4 = "f394154a";
            return 38;
        }

        p0 = p0;
        return p0;
    }
}

public interface Type_2<T0>
{
    bool Prop_0 { get; set; }

    int Prop_1 { get; set; }

    abstract Task<int> Method_2(int p0, Type_0 p1, Type_4<string, bool> p2);
}

public interface Type_3 : Type_0
{
    bool Prop_1 { get; set; }

    int Method_0(string p0);
    abstract Type_1 Method_1(Type_0 p0);
}

public interface Type_4<T0, T1> : Type_3
{
    bool Prop_1 { get; set; }

    int Method_0(string p0);
    Type_1 Method_1(Type_0 p0);
    abstract string Method_2(int p0);
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        for (int i0 = 0; i0 < 2; i0++)
        {
            Console.WriteLine("Trace 1");
        }

        await System.Threading.Tasks.Task.Yield();
        int v1 = 83;
        if (false)
        {
            await System.Threading.Tasks.Task.Yield();
            switch (v1)
            {
                case 94:
                    if (true)
                    {
                        string v2 = "45516f65";
                        Console.WriteLine(v1);
                        string v3 = v2;
                    }
                    else
                    {
                        Type_4<int, bool> v4 = default(Type_4<int, bool>);
                        int v5 = await System.Threading.Tasks.Task.FromResult(56);
                    }

                    for (int i6 = 0; i6 < 3; i6++)
                    {
                        Console.WriteLine(i6);
                        Console.WriteLine("Trace 7");
                    }

                    break;
                case 84:
                    Console.WriteLine("Trace 7");
                    break;
                case 69:
                    try
                    {
                        Type_3 v7 = default(Type_3);
                    }
                    catch (InvalidOperationException ex8)
                    {
                        bool v9 = true;
                    }

                    for (int i10 = 0; i10 < 3; i10++)
                    {
                        Type_3 v11 = default(Type_3);
                        v11 = default(Type_3);
                        int v12 = v1;
                    }

                    break;
                default:
                    await System.Threading.Tasks.Task.CompletedTask;
                    break;
            }

            await System.Threading.Tasks.Task.Yield();
        }

        for (int i13 = 0; i13 < 3; i13++)
        {
            switch (i13)
            {
                case 22:
                    try
                    {
                        Type_1 v14 = new Type_1();
                        Type_1 v15 = new Type_1();
                    }
                    catch (Exception ex16)
                    {
                        int v17 = (await System.Threading.Tasks.Task.FromResult(23)) * (54);
                    }

                    break;
                case 95:
                    Console.WriteLine("Trace 18");
                    await System.Threading.Tasks.Task.CompletedTask;
                    break;
                case 0:
                    for (int i18 = 0; i18 < 3; i18++)
                    {
                        Type_4<int, string> v19 = await System.Threading.Tasks.Task.FromResult(default(Type_4<int, string>));
                        int v20 = 54;
                        string v21 = v19.Method_2(26);
                    }

                    bool v22 = await System.Threading.Tasks.Task.FromResult(false);
                    break;
                default:
                    Type_3 v23 = await System.Threading.Tasks.Task.FromResult(default(Type_3));
                    break;
            }
        }

        await System.Threading.Tasks.Task.Yield();
        if (true)
        {
            for (int i24 = 0; i24 < 3; i24++)
            {
                for (int i25 = 0; i25 < 3; i25++)
                {
                    int v26 = i25;
                }

                Console.WriteLine("Trace 27");
            }

            await System.Threading.Tasks.Task.CompletedTask;
            try
            {
                if (false)
                {
                    Console.WriteLine(v1);
                    bool v27 = true;
                }
                else
                {
                    v1 = await System.Threading.Tasks.Task.FromResult(65);
                }
            }
            catch (ArgumentException ex28)
            {
                if (await System.Threading.Tasks.Task.FromResult(true))
                {
                    int v29 = v1;
                    Type_0 v30 = default(Type_0);
                }
            }
        }
        else
        {
            switch (v1)
            {
                case 93:
                    v1 = await System.Threading.Tasks.Task.FromResult(0);
                    break;
                case 51:
                    await System.Threading.Tasks.Task.Yield();
                    int v31 = v1;
                    break;
                default:
                    try
                    {
                        v1 = v1;
                        int v32 = v1;
                    }
                    catch (Exception ex33)
                    {
                        bool v34 = false;
                    }

                    break;
            }
        }

        Console.WriteLine("Trace 35");
        if (await System.Threading.Tasks.Task.FromResult(false))
        {
            for (int i35 = 0; i35 < 4; i35++)
            {
                v1 = 72;
            }

            if ((true) && (await System.Threading.Tasks.Task.FromResult(true)))
            {
                if ((await System.Threading.Tasks.Task.FromResult(true)) && (true))
                {
                    bool v36 = true;
                    bool v37 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(false));
                }

                try
                {
                    int v38 = 29;
                }
                catch (Exception ex39)
                {
                    bool v40 = true;
                }
            }
            else
            {
                for (int i41 = 0; i41 < 3; i41++)
                {
                    int v42 = await System.Threading.Tasks.Task.FromResult(24);
                    bool v43 = false;
                }
            }
        }
        else
        {
            for (int i44 = 0; i44 < 4; i44++)
            {
                Console.WriteLine(v1);
                i44 = (61) + (42);
            }

            try
            {
                for (int i45 = 0; i45 < 3; i45++)
                {
                    Type_0 v46 = default(Type_0);
                }
            }
            catch (Exception ex47)
            {
                for (int i48 = 0; i48 < 2; i48++)
                {
                    Type_4<int, string> v49 = default(Type_4<int, string>);
                    int v50 = await System.Threading.Tasks.Task.FromResult(86);
                }
            }

            for (int i51 = 0; i51 < 3; i51++)
            {
                try
                {
                    Type_4<int, int> v52 = default(Type_4<int, int>);
                    bool v53 = ((false) && ((true) && ((false) && (true)))) && (await System.Threading.Tasks.Task.FromResult(true));
                }
                catch (InvalidOperationException ex54)
                {
                    Type_2<int> v55 = await System.Threading.Tasks.Task.FromResult(default(Type_2<int>));
                }

                Console.WriteLine("Trace 56");
            }
        }

        if (true)
        {
            bool v56 = true;
        }
        else
        {
            await System.Threading.Tasks.Task.Yield();
            if (true)
            {
                if (await System.Threading.Tasks.Task.FromResult(true))
                {
                    Console.WriteLine("Trace 57");
                }
                else
                {
                    string v57 = (await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult("7ed7ccfa"))) + ("2023bcef");
                    string v58 = v57;
                }

                Console.WriteLine(v1);
            }

            v1 = Type_1.Prop_1;
        }

        Console.WriteLine("Program End");
    }
}