using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class Type_0
{
    public Type_2 Prop_0 { get; set; }
    public int Prop_1 { get; set; }
    public Type_3<int> Prop_2 { get; }
    public Type_4<bool, int> Prop_3 { get; set; }
}

public class Type_1
{
    public Type_2 Prop_0 { get; set; }
}

public abstract class Type_2
{
    public async Task<int> Method_0(bool p0, Type_1 p1)
    {
        for (int i0 = 0; i0 < 4; i0++)
        {
            if (((false) && (p0)) && (false))
            {
                if ((45) < (((96) - (88)) - (9)))
                {
                    p0 = false;
                    return 5;
                }

                p1 = new Type_1();
                return i0;
            }
            else
            {
                switch (i0)
                {
                    case 22:
                        int v1 = (await this.Method_0(true, new Type_1() { Prop_0 = this })) + (i0);
                        return 92;
                        break;
                    case 48:
                        Console.WriteLine(i0);
                        return (i0) - (14);
                        break;
                    default:
                        Type_2 v2 = default(Type_2);
                        return 62;
                        break;
                }

                return 22;
            }

            return (83) - ((70) * (67));
        }

        for (int i3 = 0; i3 < 3; i3++)
        {
            switch (i3)
            {
                case 70:
                    switch (53)
                    {
                        case 80:
                            bool v4 = true;
                            Type_4<bool, int> v5 = default(Type_4<bool, int>);
                            return (i3) - (56);
                            break;
                        case 24:
                            string v6 = await System.Threading.Tasks.Task.FromResult("1b0f43f2");
                            p1 = new Type_1();
                            return (i3) + (i3);
                            break;
                        default:
                            int v7 = i3;
                            return 75;
                            break;
                    }

                    for (int i8 = 0; i8 < 4; i8++)
                    {
                        Type_0 v9 = await System.Threading.Tasks.Task.FromResult(new Type_0());
                        Type_1 v10 = new Type_1();
                        bool v11 = false;
                        return await System.Threading.Tasks.Task.FromResult(64);
                    }

                    return 11;
                    break;
                case 72:
                    int v12 = 45;
                    return 42;
                    break;
                default:
                    for (int i13 = 0; i13 < 3; i13++)
                    {
                        string v14 = "e900668b";
                        return 41;
                    }

                    return 84;
                    break;
            }

            for (int i15 = 0; i15 < 2; i15++)
            {
                i3 = i3;
                i3 = await System.Threading.Tasks.Task.FromResult(88);
                if (true)
                {
                    Console.WriteLine("Trace 16");
                    Type_3<int> v16 = await System.Threading.Tasks.Task.FromResult(new Type_3<int>());
                    bool v17 = p0;
                    return 24;
                }
                else
                {
                    Console.WriteLine("Trace 18");
                    Type_4<string, bool> v18 = default(Type_4<string, bool>);
                    Console.WriteLine(p0);
                    return 60;
                }

                return 76;
            }

            await System.Threading.Tasks.Task.CompletedTask;
            return 69;
        }

        switch (39)
        {
            case 22:
                if (p0)
                {
                    await System.Threading.Tasks.Task.CompletedTask;
                    p0 = true;
                    for (int i19 = 0; i19 < 3; i19++)
                    {
                        int v20 = ((i19) + (21)) + ((53) * (46));
                        int v21 = 92;
                        return await System.Threading.Tasks.Task.FromResult(40);
                    }

                    return 0;
                }

                return 52;
                break;
            case 75:
                bool v22 = false;
                return 90;
                break;
            default:
                Console.WriteLine("TraceObj");
                return 13;
                break;
        }

        Type_1 v23 = new Type_1();
        try
        {
            Type_2 v24 = v23.Prop_0;
            return 93;
        }
        catch (ArgumentException ex25)
        {
            try
            {
                if (false)
                {
                    bool v26 = await System.Threading.Tasks.Task.FromResult(false);
                    p1 = await System.Threading.Tasks.Task.FromResult(new Type_1());
                    return 64;
                }

                return (48) + (23);
            }
            catch (InvalidOperationException ex27)
            {
                switch (69)
                {
                    case 30:
                        Console.WriteLine("Trace 28");
                        Console.WriteLine("TraceObj");
                        return await System.Threading.Tasks.Task.FromResult(61);
                        break;
                    case 41:
                        Console.WriteLine("TraceObj");
                        return 83;
                        break;
                    default:
                        v23 = new Type_1();
                        return (75) + (21);
                        break;
                }

                return await System.Threading.Tasks.Task.FromResult(94);
            }
            finally
            {
                await System.Threading.Tasks.Task.CompletedTask;
            }

            return 19;
        }

        return (62) + (73);
    }
}

public struct Type_3<T0>
{
    public Type_4<int, bool> Prop_0 { get; set; }
    public static string Prop_1 { get; set; }
    public Type_4<bool, bool> Prop_2 { get; set; }
    public Type_2 Prop_3 { get; set; }
}

public interface Type_4<T0, T1>
{
    Type_4<string, string> Prop_0 { get; set; }

    int Prop_1 { get; set; }

    int Prop_2 { get; }

    abstract bool Method_3();
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        switch (59)
        {
            case 75:
                try
                {
                    await System.Threading.Tasks.Task.CompletedTask;
                    if (true)
                    {
                        Type_0 v0 = new Type_0()
                        {
                            Prop_0 = default(Type_2),
                            Prop_1 = 7,
                            Prop_3 = default(Type_4<bool, int>)
                        };
                        bool v1 = true;
                        Type_2 v2 = default(Type_2);
                    }
                    else
                    {
                        Type_0 v3 = new Type_0();
                    }
                }
                catch (Exception ex4)
                {
                    for (int i5 = 0; i5 < 4; i5++)
                    {
                        int v6 = (await System.Threading.Tasks.Task.FromResult(96)) * (await System.Threading.Tasks.Task.FromResult(35));
                        bool v7 = await System.Threading.Tasks.Task.FromResult(false);
                        Type_2 v8 = default(Type_2);
                    }
                }
                finally
                {
                    await System.Threading.Tasks.Task.CompletedTask;
                }

                await System.Threading.Tasks.Task.Yield();
                break;
            case 73:
                try
                {
                    for (int i9 = 0; i9 < 2; i9++)
                    {
                        i9 = (i9) + ((((i9) * (i9)) * (i9)) - (43));
                        Type_2 v10 = default(Type_2);
                    }

                    int v11 = ((33) * (21)) - (86);
                }
                catch (NullReferenceException ex12)
                {
                    switch ((75) * (34))
                    {
                        case 72:
                            Type_0 v13 = new Type_0();
                            break;
                        case 70:
                            Type_1 v14 = await System.Threading.Tasks.Task.FromResult(new Type_1());
                            break;
                        default:
                            Type_0 v15 = new Type_0();
                            break;
                    }
                }
                finally
                {
                    for (int i16 = 0; i16 < 2; i16++)
                    {
                        Console.WriteLine(i16);
                        Type_4<bool, int> v17 = await System.Threading.Tasks.Task.FromResult(default(Type_4<bool, int>));
                        Type_1 v18 = new Type_1();
                    }
                }

                int v19 = 92;
                break;
            default:
                for (int i20 = 0; i20 < 4; i20++)
                {
                    try
                    {
                        Console.WriteLine("Trace 21");
                    }
                    catch (NullReferenceException ex21)
                    {
                        i20 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(34));
                    }
                }

                break;
        }

        try
        {
            for (int i22 = 0; i22 < 4; i22++)
            {
                bool v23 = false;
            }
        }
        catch (InvalidOperationException ex24)
        {
            if (true)
            {
                bool v25 = true;
            }
            else
            {
                Console.WriteLine("Trace");
            }
        }
        finally
        {
            Console.WriteLine("Trace 26");
        }

        try
        {
            switch (17)
            {
                case 42:
                    break;
                case 66:
                    Type_0 v26 = new Type_0();
                    break;
                default:
                    await System.Threading.Tasks.Task.CompletedTask;
                    break;
            }

            Console.WriteLine("Trace 27");
        }
        catch (ArgumentException ex27)
        {
            switch (67)
            {
                case 35:
                    await System.Threading.Tasks.Task.Yield();
                    Type_3<string> v28 = await System.Threading.Tasks.Task.FromResult(new Type_3<string>());
                    break;
                case 8:
                    switch (68)
                    {
                        case 72:
                            Type_0 v29 = new Type_0();
                            Type_1 v30 = new Type_1();
                            break;
                        case 66:
                            bool v31 = await System.Threading.Tasks.Task.FromResult(false);
                            break;
                        default:
                            string v32 = "beeac05f";
                            break;
                    }

                    break;
                default:
                    Type_4<string, bool> v33 = default(Type_4<string, bool>);
                    break;
            }
        }
        finally
        {
            for (int i34 = 0; i34 < 4; i34++)
            {
                for (int i35 = 0; i35 < 4; i35++)
                {
                    Type_1 v36 = new Type_1();
                    bool v37 = false;
                }
            }
        }

        for (int i38 = 0; i38 < 3; i38++)
        {
            switch (i38)
            {
                case 26:
                    if (false)
                    {
                        string v39 = "b7bbdd38";
                        int v40 = 48;
                    }

                    break;
                case 44:
                    Console.WriteLine("Trace 41");
                    try
                    {
                        Type_4<string, string> v41 = default(Type_4<string, string>);
                        Type_1 v42 = new Type_1()
                        {
                            Prop_0 = default(Type_2)
                        };
                    }
                    catch (NullReferenceException ex43)
                    {
                        Type_0 v44 = new Type_0();
                    }

                    break;
                default:
                    await System.Threading.Tasks.Task.Yield();
                    break;
            }
        }

        switch (77)
        {
            case 21:
                break;
            case 41:
                await System.Threading.Tasks.Task.CompletedTask;
                break;
            default:
                if (true)
                {
                    await System.Threading.Tasks.Task.CompletedTask;
                }
                else
                {
                    Console.WriteLine("Trace");
                    for (int i45 = 0; i45 < 2; i45++)
                    {
                        bool v46 = true;
                        Type_4<int, int> v47 = default(Type_4<int, int>);
                    }
                }

                break;
        }

        switch ((84) - (92))
        {
            case 11:
                for (int i48 = 0; i48 < 2; i48++)
                {
                    i48 = 70;
                    try
                    {
                        Type_2 v49 = default(Type_2);
                    }
                    catch (ArgumentException ex50)
                    {
                        Console.WriteLine(i48);
                    }
                    finally
                    {
                        Console.WriteLine(i48);
                    }
                }

                Type_0 v51 = new Type_0();
                break;
            case 10:
                if (true)
                {
                    await System.Threading.Tasks.Task.Yield();
                }

                break;
            default:
                break;
        }

        Console.WriteLine("Trace");
        Console.WriteLine("Trace 52");
        Console.WriteLine("Program End");
    }
}