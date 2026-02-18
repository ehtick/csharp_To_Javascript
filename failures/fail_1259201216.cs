using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public interface Type_0
{
    int Prop_1 { get; set; }

    string Prop_2 { get; set; }

    Type_4 Prop_3 { get; }

    abstract int Method_0();
}

public struct Type_1
{
    public Type_4 Prop_0 { get; set; }
}

public class Type_2 : Type_3
{
    public async System.Threading.Tasks.Task<bool> Method_0(Type_1 p0)
    {
        try
        {
            await System.Threading.Tasks.Task.CompletedTask;
            p0 = new Type_1();
            return default(System.Threading.Tasks.Task<bool>);
        }
        catch (ArgumentException ex0)
        {
            if (true)
            {
                p0 = new Type_1();
                return default(System.Threading.Tasks.Task<bool>);
            }
            else
            {
                for (int i1 = 0; i1 < 4; i1++)
                {
                    Console.WriteLine("Trace 2");
                    string v2 = "c1027d6b";
                    return default(System.Threading.Tasks.Task<bool>);
                }

                return default(System.Threading.Tasks.Task<bool>);
            }

            return default(System.Threading.Tasks.Task<bool>);
        }

        for (int i3 = 0; i3 < 4; i3++)
        {
            await System.Threading.Tasks.Task.CompletedTask;
            Console.WriteLine("Trace 4");
            await System.Threading.Tasks.Task.CompletedTask;
            return await System.Threading.Tasks.Task.FromResult(default(System.Threading.Tasks.Task<bool>));
        }

        switch (await System.Threading.Tasks.Task.FromResult(92))
        {
            case 78:
                await System.Threading.Tasks.Task.CompletedTask;
                Type_1 v4 = new Type_1();
                return default(System.Threading.Tasks.Task<bool>);
                break;
            case 28:
                for (int i5 = 0; i5 < 2; i5++)
                {
                    Console.WriteLine("Trace 6");
                    return this.Method_0(p0);
                }

                switch ((65) - (23))
                {
                    case 81:
                        for (int i6 = 0; i6 < 3; i6++)
                        {
                            p0 = new Type_1();
                            return default(System.Threading.Tasks.Task<bool>);
                        }

                        return default(System.Threading.Tasks.Task<bool>);
                        break;
                    case 74:
                        string v7 = (await System.Threading.Tasks.Task.FromResult("e74cf19b")) + (await System.Threading.Tasks.Task.FromResult("0ad5f7f2"));
                        await System.Threading.Tasks.Task.CompletedTask;
                        return default(System.Threading.Tasks.Task<bool>);
                        break;
                    default:
                        Console.WriteLine("Trace 8");
                        return await System.Threading.Tasks.Task.FromResult(default(System.Threading.Tasks.Task<bool>));
                        break;
                }

                return default(System.Threading.Tasks.Task<bool>);
                break;
            case 35:
                p0 = new Type_1();
                await System.Threading.Tasks.Task.CompletedTask;
                return default(System.Threading.Tasks.Task<bool>);
                break;
            default:
                Console.WriteLine("Trace 8");
                return default(System.Threading.Tasks.Task<bool>);
                break;
        }

        bool v8 = false;
        return this.Method_0(await System.Threading.Tasks.Task.FromResult(new Type_1()));
    }

    public string Method_1(Type_1 p0, Type_1 p1, string p2)
    {
        bool v9 = false;
        switch (p2)
        {
            case "e44d77b8":
                p2 = "577401a6";
                Type_3 v10 = default(Type_3);
                return "bec0de4f";
                break;
            case "5d68c679":
                Type_0 v11 = default(Type_0);
                if (false)
                {
                    Type_0 v12 = default(Type_0);
                    switch ((36) * (38))
                    {
                        case 10:
                            Type_4 v13 = default(Type_4);
                            return "5fbe7d92";
                            break;
                        case 16:
                            Type_2 v14 = new Type_2();
                            return "9e31f6c0";
                            break;
                        case 57:
                            Type_0 v15 = default(Type_0);
                            string v16 = ("c42d9679") + (p2);
                            return v11.Prop_2;
                            break;
                        default:
                            Type_3 v17 = default(Type_3);
                            return "cbf5889a";
                            break;
                    }

                    return "27b18614";
                }

                return p2;
                break;
            default:
                for (int i18 = 0; i18 < 2; i18++)
                {
                    if (true)
                    {
                        Console.WriteLine("TraceObj");
                        bool v19 = (v9) == (false);
                        int v20 = 50;
                        return "258578fa";
                    }

                    return p2;
                }

                return "1a7564dd";
                break;
        }

        switch (77)
        {
            case 1:
                Console.WriteLine("Trace 21");
                return this.Method_1(new Type_1(), new Type_1(), "c1e6e3f6");
                break;
            case 6:
                try
                {
                    Console.WriteLine("Trace 21");
                    return this.Method_1(new Type_1(), new Type_1(), "b682ea5c");
                }
                catch (Exception ex21)
                {
                    Type_0 v22 = default(Type_0);
                    return "a781ff6c";
                }
                finally
                {
                    for (int i23 = 0; i23 < 2; i23++)
                    {
                        int v24 = 31;
                    }
                }

                return "aadf0b22";
                break;
            default:
                Console.WriteLine(v9);
                return "7787cb8b";
                break;
        }

        Type_2 v25 = new Type_2();
        Console.WriteLine("Trace 26");
        return "d10b9422";
    }
}

public interface Type_3
{
    Type_1 Prop_1 { get; }

    abstract Type_0 Method_0(Type_0 p0);
}

public interface Type_4
{
    abstract void Method_0(bool p0);
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        if ((await await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(true)))) && ((new Type_2()) == (new Type_2())))
        {
            try
            {
                if (true)
                {
                    string v0 = "73c948a1";
                    Console.WriteLine(v0);
                }
                else
                {
                    bool v1 = false;
                    v1 = v1;
                }
            }
            catch (NullReferenceException ex2)
            {
                try
                {
                    string v3 = "7e120add";
                    Type_3 v4 = default(Type_3);
                }
                catch (NullReferenceException ex5)
                {
                    int v6 = await System.Threading.Tasks.Task.FromResult(84);
                }
            }

            if (await System.Threading.Tasks.Task.FromResult(false))
            {
                if (false)
                {
                    string v7 = "f35e8b39";
                }

                try
                {
                    string v8 = "53933a24";
                }
                catch (Exception ex9)
                {
                    string v10 = ("acd60cc7") + (((("6794532a") + ("98d11876")) + ("c4da1f49")) + ("460db2a5"));
                }

                switch (await System.Threading.Tasks.Task.FromResult(26))
                {
                    case 39:
                        break;
                    case 21:
                        Console.WriteLine("Trace 11");
                        int v11 = await System.Threading.Tasks.Task.FromResult(47);
                        break;
                    default:
                        string v12 = "442dea16";
                        break;
                }
            }
            else
            {
                Console.WriteLine("Trace 13");
            }
        }

        string v13 = "789de5c0";
        Console.WriteLine("Trace 14");
        await System.Threading.Tasks.Task.CompletedTask;
        switch (v13)
        {
            case "25a46671":
                Console.WriteLine(v13);
                break;
            case "c388bcb1":
                if (true)
                {
                    await System.Threading.Tasks.Task.CompletedTask;
                }
                else
                {
                    switch (v13)
                    {
                        case "76258813":
                            Console.WriteLine("Trace 14");
                            bool v14 = false;
                            break;
                        case "599969d3":
                            v13 = await System.Threading.Tasks.Task.FromResult("3e5296e1");
                            Type_0 v15 = default(Type_0);
                            break;
                        default:
                            int v16 = 77;
                            break;
                    }

                    bool v17 = false;
                }

                v13 = "08521a51";
                break;
            default:
                try
                {
                    switch (v13)
                    {
                        case "3ec514d2":
                            Type_3 v18 = default(Type_3);
                            bool v19 = (v13) == (await System.Threading.Tasks.Task.FromResult("ed6e3357"));
                            break;
                        case "e454e5d7":
                            Console.WriteLine(v13);
                            Type_2 v20 = new Type_2();
                            break;
                        default:
                            bool v21 = false;
                            break;
                    }

                    for (int i22 = 0; i22 < 3; i22++)
                    {
                        Console.WriteLine(i22);
                    }
                }
                catch (ArgumentException ex23)
                {
                    switch (v13)
                    {
                        case "bf1c8208":
                            string v24 = "49c316de";
                            Console.WriteLine(v24);
                            break;
                        case "38016e87":
                            string v25 = v13;
                            Console.WriteLine(v13);
                            break;
                        case "47c957b0":
                            string v26 = ("5e320b75") + ("18afb955");
                            break;
                        default:
                            int v27 = 47;
                            break;
                    }
                }
                finally
                {
                    if (true)
                    {
                        Console.WriteLine("Trace 28");
                        bool v28 = ("6fc7d184") == (await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult("e8d869a5")));
                        Type_4 v29 = await await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(default(Type_4))));
                    }
                }

                break;
        }

        bool v30 = await System.Threading.Tasks.Task.FromResult(true);
        await System.Threading.Tasks.Task.CompletedTask;
        switch ((await System.Threading.Tasks.Task.FromResult(19)) * (18))
        {
            case 34:
                v13 = "78f5c4cb";
                Type_4 v31 = await System.Threading.Tasks.Task.FromResult(default(Type_4));
                break;
            case 38:
                if (await System.Threading.Tasks.Task.FromResult(false))
                {
                    v13 = "b8618d04";
                }
                else
                {
                    if ((false) && (true))
                    {
                        Type_4 v32 = default(Type_4);
                        Console.WriteLine("Trace 33");
                    }
                    else
                    {
                        v30 = false;
                        string v33 = v13;
                        bool v34 = false;
                    }

                    Type_4 v35 = default(Type_4);
                }

                v30 = v30;
                break;
            default:
                for (int i36 = 0; i36 < 2; i36++)
                {
                    int v37 = 75;
                    Console.WriteLine("Trace 38");
                }

                break;
        }

        Console.WriteLine("Trace 38");
        await System.Threading.Tasks.Task.CompletedTask;
        Console.WriteLine("Program End");
    }
}