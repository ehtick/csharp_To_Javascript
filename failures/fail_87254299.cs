using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class Type_0
{
    public string Prop_0 { get; }
    public Type_3 Prop_1 { get; set; }
}

public struct Type_1
{
    public bool Prop_0 { get; set; }
}

public struct Type_2<T0, T1>
{
    public static bool Prop_0 { get; set; }
}

public struct Type_4<T0>
{
    public bool Prop_0 { get; set; }
    public static bool Prop_1 { get; set; }

    public abstract class Type_3
    {
        public static string Method_0()
        {
            Type_1 v0 = new Type_1();
            Type_1 v1 = new Type_1();
            if (false)
            {
                try
                {
                    for (int i2 = 0; i2 < 2; i2++)
                    {
                        Console.WriteLine("Trace 3");
                        Type_4<bool>.Type_3 v3 = default(Type_4<bool>.Type_3);
                        Console.WriteLine("TraceObj");
                        return Type_4<bool>.Type_3.Method_0();
                    }

                    bool v4 = Type_4<bool>.Prop_1;
                    return Type_4<int>.Type_3.Method_0();
                }
                catch (ArgumentException ex5)
                {
                    bool v6 = Type_2<string, string>.Prop_0;
                    return "4f7fe524";
                }

                return "3bbcf046";
            }

            if (Type_4<int>.Prop_1)
            {
                switch (15)
                {
                    case 8:
                        Type_4<bool>.Type_3 v7 = default(Type_4<bool>.Type_3);
                        try
                        {
                            int v8 = (15) + (7);
                            Console.WriteLine(v8);
                            return "93f32e96";
                        }
                        catch (InvalidOperationException ex9)
                        {
                            Type_1 v10 = new Type_1();
                            return Type_4<bool>.Type_3.Method_0();
                        }
                        finally
                        {
                            string v11 = "1dc10296";
                        }

                        return (("60f426be") + ("ce0243f4")) + (Type_4<int>.Type_3.Method_0());
                        break;
                    case 73:
                        int v12 = 53;
                        switch (v12)
                        {
                            case 34:
                                Console.WriteLine("Trace 13");
                                return "ac4cd1c5";
                                break;
                            case 71:
                                Type_0 v13 = new Type_0()
                                {
                                    Prop_1 = default(Type_3)
                                };
                                string v14 = "744bb79f";
                                return Type_4<string>.Type_3.Method_0();
                                break;
                            case 22:
                                Console.WriteLine(v12);
                                Type_1 v15 = new Type_1();
                                return "1d0a3a54";
                                break;
                            default:
                                Type_2<int, string> v16 = new Type_2<int, string>();
                                return ("2a5caec1") + ("67cf8d83");
                                break;
                        }

                        return "f8c4414f";
                        break;
                    default:
                        for (int i17 = 0; i17 < 2; i17++)
                        {
                            int v18 = (48) + (85);
                            return Type_4<string>.Type_3.Method_0();
                        }

                        return "46f2d08f";
                        break;
                }

                int v19 = 28;
                return "94197fa7";
            }

            bool v20 = true;
            return "3b5dda7e";
        }
    }
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        if (false)
        {
            switch (await System.Threading.Tasks.Task.FromResult(85))
            {
                case 24:
                    Type_4<bool>.Type_3 v0 = default(Type_4<bool>.Type_3);
                    switch (14)
                    {
                        case 14:
                            Type_2<int, int> v1 = new Type_2<int, int>();
                            bool v2 = false;
                            break;
                        case 3:
                            Console.WriteLine("Trace 3");
                            bool v3 = true;
                            break;
                        default:
                            Console.WriteLine("Trace 4");
                            break;
                    }

                    break;
                case 19:
                    for (int i4 = 0; i4 < 4; i4++)
                    {
                        Type_1 v5 = new Type_1();
                        Type_1 v6 = new Type_1();
                        Type_2<bool, bool> v7 = new Type_2<bool, bool>();
                    }

                    try
                    {
                        Type_4<int>.Type_3 v8 = await System.Threading.Tasks.Task.FromResult(default(Type_4<int>.Type_3));
                    }
                    catch (NullReferenceException ex9)
                    {
                    }
                    finally
                    {
                        Type_4<int>.Type_3 v10 = default(Type_4<int>.Type_3);
                    }

                    break;
                case 77:
                    Type_1 v11 = await System.Threading.Tasks.Task.FromResult(new Type_1());
                    break;
                default:
                    break;
            }

            try
            {
                switch (await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(6)))
                {
                    case 3:
                        break;
                    case 59:
                        Type_2<string, bool> v12 = new Type_2<string, bool>();
                        Type_4<bool> v13 = new Type_4<bool>();
                        break;
                    default:
                        string v14 = "0545510c";
                        break;
                }
            }
            catch (ArgumentException ex15)
            {
                Console.WriteLine("Trace 16");
            }
            finally
            {
                await System.Threading.Tasks.Task.CompletedTask;
            }

            int v16 = 11;
        }

        await System.Threading.Tasks.Task.CompletedTask;
        for (int i17 = 0; i17 < 2; i17++)
        {
            await System.Threading.Tasks.Task.CompletedTask;
            await System.Threading.Tasks.Task.Yield();
            await System.Threading.Tasks.Task.CompletedTask;
        }

        switch (await System.Threading.Tasks.Task.FromResult(56))
        {
            case 53:
                for (int i18 = 0; i18 < 3; i18++)
                {
                    Console.WriteLine("Trace 19");
                    await System.Threading.Tasks.Task.Yield();
                }

                break;
            case 39:
                try
                {
                    for (int i19 = 0; i19 < 2; i19++)
                    {
                        string v20 = "7b6b00c3";
                        Console.WriteLine("Trace 21");
                    }
                }
                catch (ArgumentException ex21)
                {
                    for (int i22 = 0; i22 < 4; i22++)
                    {
                        Type_1 v23 = new Type_1();
                        Type_4<string> v24 = new Type_4<string>();
                        int v25 = 35;
                    }
                }

                await System.Threading.Tasks.Task.CompletedTask;
                break;
            default:
                Type_4<string> v26 = await System.Threading.Tasks.Task.FromResult(new Type_4<string>());
                break;
        }

        switch (85)
        {
            case 76:
                if (await System.Threading.Tasks.Task.FromResult(false))
                {
                    await System.Threading.Tasks.Task.Yield();
                    switch (31)
                    {
                        case 12:
                            break;
                        case 97:
                            bool v27 = true;
                            break;
                        default:
                            string v28 = "e31d8e1a";
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Trace 29");
                    try
                    {
                        Type_4<string> v29 = new Type_4<string>();
                        string v30 = "186d0ee6";
                    }
                    catch (Exception ex31)
                    {
                        bool v32 = (true) && (false);
                    }

                    Type_2<int, string> v33 = new Type_2<int, string>();
                }

                break;
            case 44:
                break;
            default:
                Console.WriteLine("Trace 34");
                break;
        }

        for (int i34 = 0; i34 < 3; i34++)
        {
            i34 = 87;
            await System.Threading.Tasks.Task.Yield();
            if ((true) && (true))
            {
                i34 = 46;
                switch (i34)
                {
                    case 66:
                        string v35 = ("02291f2f") + ("b040ea66");
                        break;
                    case 85:
                        i34 = await System.Threading.Tasks.Task.FromResult(2);
                        i34 = i34;
                        break;
                    default:
                        Console.WriteLine(i34);
                        break;
                }

                i34 = 87;
            }
        }

        Type_1 v36 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(new Type_1()));
        switch ((94) + (57))
        {
            case 11:
                await System.Threading.Tasks.Task.Yield();
                try
                {
                    string v37 = "70254a29";
                    await System.Threading.Tasks.Task.CompletedTask;
                }
                catch (InvalidOperationException ex38)
                {
                    switch (await System.Threading.Tasks.Task.FromResult(87))
                    {
                        case 94:
                            Type_1 v39 = new Type_1();
                            string v40 = Type_4<int>.Type_3.Method_0();
                            break;
                        case 39:
                            Type_0 v41 = new Type_0();
                            break;
                        default:
                            Type_1 v42 = new Type_1();
                            break;
                    }
                }

                break;
            case 21:
                v36 = new Type_1();
                break;
            default:
                v36 = await System.Threading.Tasks.Task.FromResult(new Type_1());
                break;
        }

        Console.WriteLine("TraceObj");
        for (int i43 = 0; i43 < 4; i43++)
        {
            await System.Threading.Tasks.Task.CompletedTask;
            await System.Threading.Tasks.Task.CompletedTask;
            for (int i44 = 0; i44 < 4; i44++)
            {
                await System.Threading.Tasks.Task.Yield();
                Console.WriteLine("TraceObj");
                Console.WriteLine(i44);
            }
        }

        Console.WriteLine("Program End");
    }
}