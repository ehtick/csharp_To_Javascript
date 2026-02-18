using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public struct Type_0<T0>
{
    public static Type_4<string> Prop_1 { get; set; }

    public Type_3<int, string> Method_0(string p0, string p1)
    {
        bool v0 = (true) && (false);
        Type_4<int> v1 = default(Type_4<int>);
        Console.WriteLine("TraceObj");
        Console.WriteLine("TraceObj");
        return default(Type_3<int, string>);
    }
}

public class Type_1<T0, T1>
{
    public Type_0<bool> Prop_0 { get; set; }
}

public interface Type_2
{
    string Prop_3 { get; set; }

    abstract Type_4<string> Method_0(Type_0<int> p0, Type_1<bool, string> p1, Type_4<string> p2);
    abstract Task<bool> Method_1();
    abstract Type_3<int, int> Method_2(bool p0);
}

public interface Type_3<T0, T1> : Type_2
{
    string Prop_3 { get; set; }

    int Prop_0 { get; set; }

    Type_4<string> Method_0(Type_0<int> p0, Type_1<bool, string> p1, Type_4<string> p2);
    Task<bool> Method_1();
    Type_3<int, int> Method_2(bool p0);
    abstract Type_2 Method_3(int p0);
}

public interface Type_4<T0> : Type_2
{
    string Prop_3 { get; set; }

    Type_4<string> Method_0(Type_0<int> p0, Type_1<bool, string> p1, Type_4<string> p2);
    Task<bool> Method_1();
    Type_3<int, int> Method_2(bool p0);
    abstract Type_3<int, int> Method_3(bool p0);
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        try
        {
        }
        catch (InvalidOperationException ex0)
        {
            Console.WriteLine("Trace");
        }
        finally
        {
            Console.WriteLine("Trace");
        }

        await System.Threading.Tasks.Task.CompletedTask;
        try
        {
            Console.WriteLine("Trace 1");
        }
        catch (Exception ex1)
        {
            Type_1<bool, int> v2 = new Type_1<bool, int>();
        }

        switch (await System.Threading.Tasks.Task.FromResult(72))
        {
            case 17:
                try
                {
                    string v3 = await System.Threading.Tasks.Task.FromResult("bbba2eae");
                }
                catch (Exception ex4)
                {
                    switch (7)
                    {
                        case 9:
                            string v5 = "641f1376";
                            Console.WriteLine(v5);
                            break;
                        case 27:
                            Type_0<string> v6 = new Type_0<string>();
                            string v7 = await System.Threading.Tasks.Task.FromResult("83c0667b");
                            break;
                        default:
                            Type_1<bool, bool> v8 = new Type_1<bool, bool>();
                            break;
                    }
                }

                break;
            case 91:
                for (int i9 = 0; i9 < 3; i9++)
                {
                    try
                    {
                        Type_2 v10 = default(Type_2);
                    }
                    catch (NullReferenceException ex11)
                    {
                        bool v12 = (false) && (true);
                    }
                    finally
                    {
                        i9 = i9;
                    }

                    for (int i13 = 0; i13 < 3; i13++)
                    {
                        Console.WriteLine(i9);
                        Console.WriteLine(i13);
                    }

                    try
                    {
                        bool v14 = (true) && (false);
                    }
                    catch (Exception ex15)
                    {
                        int v16 = 76;
                    }
                }

                switch (42)
                {
                    case 67:
                        switch (73)
                        {
                            case 57:
                                bool v17 = true;
                                break;
                            case 42:
                                Type_1<bool, bool> v18 = new Type_1<bool, bool>();
                                break;
                            default:
                                bool v19 = await System.Threading.Tasks.Task.FromResult(true);
                                break;
                        }

                        Type_4<int> v20 = default(Type_4<int>);
                        break;
                    case 23:
                        if (false)
                        {
                            string v21 = ("2d20fa45") + ("07fd6ded");
                            Type_3<int, bool> v22 = default(Type_3<int, bool>);
                        }

                        break;
                    case 69:
                        await System.Threading.Tasks.Task.Yield();
                        await System.Threading.Tasks.Task.CompletedTask;
                        break;
                    default:
                        switch (20)
                        {
                            case 86:
                                Type_4<string> v23 = default(Type_4<string>);
                                int v24 = 86;
                                break;
                            case 8:
                                Type_0<string> v25 = new Type_0<string>();
                                break;
                            case 25:
                                Type_4<string> v26 = default(Type_4<string>);
                                break;
                            default:
                                break;
                        }

                        break;
                }

                break;
            default:
                await System.Threading.Tasks.Task.Yield();
                break;
        }

        await System.Threading.Tasks.Task.CompletedTask;
        switch (70)
        {
            case 8:
                if (false)
                {
                    Type_2 v27 = default(Type_2);
                    if (true)
                    {
                        Type_0<bool> v28 = await System.Threading.Tasks.Task.FromResult(new Type_0<bool>());
                        Type_0<int> v29 = new Type_0<int>();
                        Type_3<int, int> v30 = default(Type_3<int, int>);
                    }

                    try
                    {
                        Type_4<int> v31 = default(Type_4<int>);
                    }
                    catch (Exception ex32)
                    {
                        v27 = default(Type_2);
                    }
                    finally
                    {
                        int v33 = 48;
                    }
                }

                switch (5)
                {
                    case 7:
                        bool v34 = true;
                        Type_3<string, bool> v35 = default(Type_3<string, bool>);
                        break;
                    case 70:
                        for (int i36 = 0; i36 < 2; i36++)
                        {
                            bool v37 = true;
                            i36 = 32;
                        }

                        if (await System.Threading.Tasks.Task.FromResult(true))
                        {
                            Type_0<string> v38 = new Type_0<string>();
                        }
                        else
                        {
                            int v39 = ((67) * (await System.Threading.Tasks.Task.FromResult(78))) * (35);
                            int v40 = await System.Threading.Tasks.Task.FromResult(88);
                        }

                        break;
                    case 82:
                        switch ((((12) - (await System.Threading.Tasks.Task.FromResult(93))) - (await System.Threading.Tasks.Task.FromResult(63))) - (await System.Threading.Tasks.Task.FromResult(64)))
                        {
                            case 35:
                                int v41 = 32;
                                v41 = 91;
                                break;
                            case 5:
                                Type_0<bool> v42 = new Type_0<bool>();
                                break;
                            default:
                                Type_2 v43 = default(Type_2);
                                break;
                        }

                        switch (39)
                        {
                            case 49:
                                Type_1<int, int> v44 = await System.Threading.Tasks.Task.FromResult(new Type_1<int, int>());
                                break;
                            case 2:
                                Type_2 v45 = default(Type_2);
                                break;
                            default:
                                Type_3<int, string> v46 = default(Type_3<int, string>);
                                break;
                        }

                        break;
                    default:
                        string v47 = "d385b581";
                        break;
                }

                break;
            case 56:
                if (true)
                {
                    switch (0)
                    {
                        case 96:
                            break;
                        case 64:
                            int v48 = 4;
                            string v49 = "ae15fd1c";
                            break;
                        default:
                            Type_0<bool> v50 = new Type_0<bool>();
                            break;
                    }
                }

                if (await System.Threading.Tasks.Task.FromResult(true))
                {
                    Console.WriteLine("Trace");
                    bool v51 = true;
                    v51 = false;
                }
                else
                {
                    string v52 = await System.Threading.Tasks.Task.FromResult("43d936b4");
                }

                break;
            case 48:
                try
                {
                }
                catch (Exception ex53)
                {
                    await System.Threading.Tasks.Task.Yield();
                }

                Type_1<bool, bool> v54 = new Type_1<bool, bool>();
                break;
            default:
                int v55 = 85;
                break;
        }

        try
        {
        }
        catch (NullReferenceException ex56)
        {
            int v57 = (11) + (49);
        }

        for (int i58 = 0; i58 < 2; i58++)
        {
            await System.Threading.Tasks.Task.Yield();
            await System.Threading.Tasks.Task.Yield();
            bool v59 = (true) == (false);
        }

        int v60 = 21;
        Console.WriteLine("Program End");
    }
}