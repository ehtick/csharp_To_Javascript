using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public interface Type_0
{
    Type_0 Prop_0 { get; set; }

    Type_2 Prop_1 { get; }

    abstract Type_2 Method_2(int p0, bool p1);
    abstract System.Threading.Tasks.Task<string> Method_3();
}

public interface Type_1
{
    abstract Type_3 Method_0(Type_0 p0, string p1, Type_0 p2);
}

public struct Type_2
{
    public static Type_4 Prop_0 { get; set; }
    public static int Prop_2 { get; }

    public int Method_1(bool p0, Type_3 p1, Type_4 p2)
    {
        Console.WriteLine("TraceObj");
        try
        {
            p0 = true;
            return 2;
        }
        catch (InvalidOperationException ex0)
        {
            p1 = p1;
            return this.Method_1(false, p1, default(Type_4));
        }

        switch (10)
        {
            case 41:
                switch (3)
                {
                    case 99:
                        string v1 = "8f2b6fff";
                        return (47) + (p1.Method_0(64, default(Type_0), 11));
                        break;
                    case 4:
                        switch (51)
                        {
                            case 19:
                                Type_4 v2 = Type_2.Prop_0;
                                return 38;
                                break;
                            case 42:
                                int v3 = (p1.Method_0(15, default(Type_0), (45) * (38))) - (this.Method_1(true, default(Type_3), default(Type_4)));
                                return p2.Method_3();
                                break;
                            default:
                                Type_0 v4 = default(Type_0);
                                return 26;
                                break;
                        }

                        return 76;
                        break;
                    case 22:
                        for (int i5 = 0; i5 < 2; i5++)
                        {
                            string v6 = "e8f9fbe0";
                            return 25;
                        }

                        return 51;
                        break;
                    default:
                        bool v7 = true;
                        return (21) * (46);
                        break;
                }

                return 45;
                break;
            case 53:
                if (true)
                {
                    p1 = default(Type_3);
                    try
                    {
                        p1 = default(Type_3);
                        return 6;
                    }
                    catch (Exception ex8)
                    {
                        int v9 = 13;
                        return 80;
                    }
                    finally
                    {
                        Type_4 v10 = Type_2.Prop_0;
                    }

                    return 1;
                }
                else
                {
                    int v11 = 58;
                    return 58;
                }

                return 25;
                break;
            case 62:
                try
                {
                    switch (60)
                    {
                        case 59:
                            Console.WriteLine("Trace 12");
                            return (8) - (85);
                            break;
                        case 31:
                            Type_1 v12 = default(Type_1);
                            Type_4 v13 = default(Type_4);
                            return Type_2.Prop_2;
                            break;
                        default:
                            bool v14 = p0;
                            return (55) - (79);
                            break;
                    }

                    return ((69) + (24)) * (21);
                }
                catch (Exception ex15)
                {
                    for (int i16 = 0; i16 < 4; i16++)
                    {
                        Console.WriteLine("TraceObj");
                        bool v17 = true;
                        Type_2 v18 = new Type_2();
                        return p2.Method_3();
                    }

                    return 30;
                }

                return Type_2.Prop_2;
                break;
            default:
                Console.WriteLine("TraceObj");
                return 49;
                break;
        }

        return 29;
    }

    public Type_1 Method_3(bool p0, Type_3 p1)
    {
        p1 = default(Type_3);
        Console.WriteLine("Trace 19");
        for (int i19 = 0; i19 < 2; i19++)
        {
            switch (50)
            {
                case 96:
                    Console.WriteLine(i19);
                    return default(Type_1);
                    break;
                case 17:
                    try
                    {
                        Console.WriteLine("Trace 20");
                        return this.Method_3(p0, p1);
                    }
                    catch (InvalidOperationException ex20)
                    {
                        Type_2 v21 = this;
                        return default(Type_1);
                    }
                    finally
                    {
                        string v22 = "5afba248";
                    }

                    for (int i23 = 0; i23 < 3; i23++)
                    {
                        bool v24 = false;
                        Type_2 v25 = new Type_2();
                        return default(Type_1);
                    }

                    return this.Method_3(false, default(Type_3));
                    break;
                case 44:
                    switch (15)
                    {
                        case 96:
                            Type_3 v26 = p1;
                            Type_0 v27 = default(Type_0);
                            return default(Type_1);
                            break;
                        case 66:
                            Console.WriteLine("Trace 28");
                            string v28 = (("4c48dadb") + ("ac4ec54a")) + ("0834b6cf");
                            return default(Type_1);
                            break;
                        default:
                            Console.WriteLine("Trace 29");
                            return this.Method_3(p0, default(Type_3));
                            break;
                    }

                    for (int i29 = 0; i29 < 3; i29++)
                    {
                        Type_4 v30 = default(Type_4);
                        return default(Type_1);
                    }

                    return default(Type_1);
                    break;
                default:
                    int v31 = ((24) - (11)) + (67);
                    return default(Type_1);
                    break;
            }

            int v32 = this.Method_1((p0) == (true), default(Type_3), default(Type_4));
            return default(Type_1);
        }

        p0 = false;
        for (int i33 = 0; i33 < 3; i33++)
        {
            p1 = default(Type_3);
            Type_2 v34 = new Type_2();
            Type_2 v35 = new Type_2();
            return default(Type_1);
        }

        return default(Type_1);
    }
}

public interface Type_3
{
    abstract int Method_0(int p0, Type_0 p1, int p2);
    abstract Type_0 Method_1(Type_1 p0);
}

public interface Type_4
{
    Type_4 Prop_2 { get; set; }

    abstract Type_4 Method_0(bool p0);
    abstract System.Threading.Tasks.Task<Type_4> Method_1();
    abstract int Method_3();
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        Type_4 v0 = default(Type_4);
        for (int i1 = 0; i1 < 4; i1++)
        {
            Type_1 v2 = default(Type_1);
        }

        await System.Threading.Tasks.Task.CompletedTask;
        await System.Threading.Tasks.Task.CompletedTask;
        await System.Threading.Tasks.Task.CompletedTask;
        v0 = Type_2.Prop_0;
        v0 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(default(Type_4)));
        Console.WriteLine("Trace 3");
        await System.Threading.Tasks.Task.CompletedTask;
        for (int i3 = 0; i3 < 2; i3++)
        {
            try
            {
                switch (7)
                {
                    case 20:
                        Console.WriteLine(i3);
                        int v4 = await System.Threading.Tasks.Task.FromResult(29);
                        break;
                    case 50:
                        int v5 = (29) + ((i3) - (65));
                        break;
                    case 76:
                        bool v6 = false;
                        Console.WriteLine("TraceObj");
                        break;
                    default:
                        int v7 = await System.Threading.Tasks.Task.FromResult(69);
                        break;
                }

                for (int i8 = 0; i8 < 2; i8++)
                {
                    int v9 = 55;
                    Console.WriteLine("Trace 10");
                }
            }
            catch (ArgumentException ex10)
            {
                try
                {
                    int v11 = 19;
                    int v12 = v11;
                }
                catch (ArgumentException ex13)
                {
                    Console.WriteLine(i3);
                }
            }
        }

        Console.WriteLine("Program End");
    }
}