using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public struct Type_0<T0>
{
    public int Prop_1 { get; }

    public static string Method_0(Type_4 p0, Type_2 p1, Type_2 p2)
    {
        Console.WriteLine("Trace 0");
        p1 = new Type_2();
        Console.WriteLine("TraceObj");
        switch (p2.Prop_0)
        {
            case 8:
                if (false)
                {
                    if (true)
                    {
                        Console.WriteLine("Trace 0");
                        return ("5b9e0038") + ("44699fc4");
                    }
                    else
                    {
                        int v0 = 95;
                        int v1 = 8;
                        Console.WriteLine(v0);
                        return "41321b05";
                    }

                    Type_3 v2 = p0.Method_0("d1402aa8", 88);
                    return "7b67ffb9";
                }

                return "15be14ea";
                break;
            case 93:
                switch (p2.Prop_0)
                {
                    case 78:
                        bool v3 = (false) == (true);
                        Console.WriteLine("Trace 4");
                        return Type_0<int>.Method_0(new Type_4(), new Type_2(), new Type_2());
                        break;
                    case 91:
                        switch (6)
                        {
                            case 98:
                                Type_0<string> v4 = new Type_0<string>();
                                p1 = p2;
                                return "306ea78f";
                                break;
                            case 39:
                                int v5 = 79;
                                Console.WriteLine("TraceObj");
                                return Type_0<string>.Method_0(new Type_4(), new Type_2(), p1);
                                break;
                            default:
                                Type_0<string> v6 = new Type_0<string>();
                                return "c59df702";
                                break;
                        }

                        for (int i7 = 0; i7 < 2; i7++)
                        {
                            Type_2 v8 = new Type_2();
                            return "b51bac9a";
                        }

                        return "0a0ad58c";
                        break;
                    case 3:
                        if (((("3f0b8a9e") + ("05d36eee")) == (Type_0<int>.Method_0(new Type_4(), new Type_2(), new Type_2()))) && (true))
                        {
                            bool v9 = true;
                            Console.WriteLine("TraceObj");
                            return "3a154317";
                        }
                        else
                        {
                            Type_3 v10 = new Type_3();
                            Console.WriteLine("TraceObj");
                            string v11 = "a316feb8";
                            return v11;
                        }

                        return "2f025e48";
                        break;
                    default:
                        string v12 = "6935ace1";
                        return "747f8faa";
                        break;
                }

                p1 = new Type_2();
                return Type_0<bool>.Method_0(new Type_4(), new Type_2(), new Type_2());
                break;
            default:
                p1 = p2;
                return "d2b988c5";
                break;
        }

        switch (48)
        {
            case 16:
                switch (89)
                {
                    case 70:
                        if (true)
                        {
                            Type_0<int> v13 = new Type_0<int>();
                            return "4d04bf44";
                        }

                        return "2b476a4d";
                        break;
                    case 81:
                        Type_2 v14 = new Type_2();
                        Type_3 v15 = new Type_3();
                        return "0fa485d0";
                        break;
                    default:
                        if (false)
                        {
                            Console.WriteLine("Trace 16");
                            string v16 = Type_0<int>.Method_0(p0, p2, new Type_2());
                            string v17 = ("370f172a") + ("17f3acb9");
                            return ("21b93386") + (v16);
                        }
                        else
                        {
                            Type_3 v18 = p0.Method_0(Type_0<bool>.Method_0(new Type_4(), new Type_2(), new Type_2()), 43);
                            p2 = p2;
                            Console.WriteLine("TraceObj");
                            return "89bdffd1";
                        }

                        return Type_0<string>.Method_0(new Type_4(), new Type_2(), p2);
                        break;
                }

                p1 = new Type_2();
                return ("0befaa6f") + ("28406b57");
                break;
            case 8:
                Type_3.Type_1 v19 = new Type_3.Type_1();
                return "1e0fdd10";
                break;
            case 99:
                p0 = new Type_4();
                return "54cd8aa7";
                break;
            default:
                p2 = new Type_2();
                return Type_0<bool>.Method_0(new Type_4(), new Type_2(), new Type_2());
                break;
        }

        return "cd819558";
    }
}

public struct Type_2
{
    public int Prop_0 { get; }
    public Type_3.Type_1 Prop_2 { get; }

    public async System.Threading.Tasks.Task<Type_3.Type_1> Method_1(Type_4 p0)
    {
        for (int i20 = 0; i20 < 3; i20++)
        {
            Console.WriteLine("Trace 21");
            string v21 = ("c773f3b1") + (await System.Threading.Tasks.Task.FromResult("38a9b153"));
            return await System.Threading.Tasks.Task.FromResult(default(System.Threading.Tasks.Task<Type_3.Type_1>));
        }

        Console.WriteLine("TraceObj");
        try
        {
            for (int i22 = 0; i22 < 2; i22++)
            {
                for (int i23 = 0; i23 < 3; i23++)
                {
                    bool v24 = true;
                    return default(System.Threading.Tasks.Task<Type_3.Type_1>);
                }

                i22 = i22;
                await System.Threading.Tasks.Task.CompletedTask;
                return default(System.Threading.Tasks.Task<Type_3.Type_1>);
            }

            return default(System.Threading.Tasks.Task<Type_3.Type_1>);
        }
        catch (ArgumentException ex25)
        {
            bool v26 = true;
            return default(System.Threading.Tasks.Task<Type_3.Type_1>);
        }
        finally
        {
            Type_4 v27 = p0;
        }

        if ((await System.Threading.Tasks.Task.FromResult(false)) && (false))
        {
            int v28 = (this.Prop_0) + ((37) + (50));
            return default(System.Threading.Tasks.Task<Type_3.Type_1>);
        }

        await System.Threading.Tasks.Task.CompletedTask;
        return default(System.Threading.Tasks.Task<Type_3.Type_1>);
    }

    public void Method_3(Type_0<int> p0, Type_3.Type_1 p1)
    {
        p0 = new Type_0<int>();
        switch (3)
        {
            case 76:
                for (int i29 = 0; i29 < 4; i29++)
                {
                    p0 = new Type_0<int>();
                    try
                    {
                        bool v30 = true;
                    }
                    catch (Exception ex31)
                    {
                        int v32 = 90;
                        return;
                    }

                    for (int i33 = 0; i33 < 3; i33++)
                    {
                        Type_2 v34 = new Type_2();
                        return;
                    }
                }

                switch (21)
                {
                    case 81:
                        string v35 = "009f28d6";
                        return;
                        break;
                    case 56:
                        bool v36 = true;
                        break;
                    default:
                        try
                        {
                            bool v37 = (false) && ((false) && (true));
                            Type_4 v38 = new Type_4();
                            return;
                        }
                        catch (ArgumentException ex39)
                        {
                            int v40 = this.Prop_0;
                        }
                        finally
                        {
                            bool v41 = false;
                        }

                        break;
                }

                return;
                break;
            case 13:
                Console.WriteLine("Trace 42");
                break;
            case 87:
                break;
            default:
                if (true)
                {
                    for (int i42 = 0; i42 < 4; i42++)
                    {
                    }

                    Type_3.Type_1 v43 = new Type_3.Type_1();
                    if (true)
                    {
                        bool v44 = true;
                        bool v45 = p1.Method_0("9a236e89", new Type_0<int>());
                    }
                    else
                    {
                        Type_3 v46 = new Type_3();
                        bool v47 = v46.Prop_0;
                        Type_0<bool> v48 = new Type_0<bool>();
                    }
                }
                else
                {
                    switch (54)
                    {
                        case 79:
                            int v49 = p0.Prop_1;
                            return;
                            break;
                        case 86:
                            int v50 = 2;
                            p1 = new Type_3.Type_1();
                            break;
                        case 90:
                            Console.WriteLine("Trace 51");
                            return;
                            break;
                        default:
                            bool v51 = true;
                            return;
                            break;
                    }

                    Type_0<string> v52 = new Type_0<string>();
                    return;
                }

                break;
        }

        Console.WriteLine("Trace 53");
        bool v53 = true;
        p0 = new Type_0<int>();
    }
}

public struct Type_3
{
    public bool Prop_0 { get; set; }

    public struct Type_1
    {
        public bool Method_0(string p0, Type_0<int> p1)
        {
            Type_3.Type_1 v54 = new Type_3.Type_1();
            if (v54.Method_0(("6084ff93") + ("a8abce05"), new Type_0<int>()))
            {
                try
                {
                    bool v55 = (true) == (false);
                    if (v55)
                    {
                        bool v56 = true;
                        return this.Method_0(p0, p1);
                    }

                    return v54.Method_0((p0) + (p0), new Type_0<int>());
                }
                catch (NullReferenceException ex57)
                {
                    string v58 = Type_0<string>.Method_0(new Type_4(), new Type_2(), new Type_2());
                    return false;
                }

                Type_3.Type_1 v59 = new Type_3.Type_1();
                return (true) && (v59.Method_0(("a09a0a9f") + ("5a5c8090"), new Type_0<int>()));
            }

            for (int i60 = 0; i60 < 3; i60++)
            {
                Console.WriteLine("TraceObj");
                return true;
            }

            for (int i61 = 0; i61 < 3; i61++)
            {
                Console.WriteLine("TraceObj");
                return false;
            }

            for (int i62 = 0; i62 < 4; i62++)
            {
                try
                {
                    switch (p1.Prop_1)
                    {
                        case 54:
                            Type_2 v63 = new Type_2();
                            int v64 = 6;
                            return true;
                            break;
                        case 25:
                            bool v65 = false;
                            Type_3 v66 = new Type_3();
                            return true;
                            break;
                        case 62:
                            string v67 = (("80d6d5f7") + ("1bff2e06")) + (Type_0<string>.Method_0(new Type_4(), new Type_2(), new Type_2()));
                            return false;
                            break;
                        default:
                            Console.WriteLine("TraceObj");
                            return (2) < (31);
                            break;
                    }

                    return true;
                }
                catch (NullReferenceException ex68)
                {
                    Console.WriteLine("Trace 69");
                    return this.Method_0("03939ec1", new Type_0<int>());
                }
                finally
                {
                    for (int i69 = 0; i69 < 3; i69++)
                    {
                        i62 = p1.Prop_1;
                        Type_0<bool> v70 = new Type_0<bool>();
                    }
                }

                Console.WriteLine(i62);
                return true;
            }

            return (v54.Method_0(p0, p1)) && (v54.Method_0("47f1c22c", new Type_0<int>()));
        }
    }
}

public class Type_4
{
    public Type_3 Method_0(string p0, int p1)
    {
        Type_0<bool> v71 = new Type_0<bool>();
        Type_2 v72 = new Type_2();
        Type_4 v73 = new Type_4();
        switch (v71.Prop_1)
        {
            case 31:
                v72 = new Type_2();
                return new Type_3()
                {
                    Prop_0 = false
                };
                break;
            case 69:
                int v74 = p1;
                try
                {
                    bool v75 = false;
                    return new Type_3();
                }
                catch (ArgumentException ex76)
                {
                    return new Type_3();
                }

                return new Type_3();
                break;
            default:
                bool v77 = false;
                return new Type_3();
                break;
        }

        return new Type_3();
    }
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        for (int i0 = 0; i0 < 2; i0++)
        {
            try
            {
                await System.Threading.Tasks.Task.CompletedTask;
                await System.Threading.Tasks.Task.CompletedTask;
            }
            catch (InvalidOperationException ex1)
            {
                switch (i0)
                {
                    case 38:
                        Console.WriteLine(i0);
                        break;
                    case 29:
                        int v2 = (await System.Threading.Tasks.Task.FromResult(77)) + (7);
                        Console.WriteLine(v2);
                        break;
                    case 20:
                        int v3 = (44) - (77);
                        break;
                    default:
                        bool v4 = true;
                        break;
                }
            }

            i0 = (await System.Threading.Tasks.Task.FromResult(39)) + (i0);
            for (int i5 = 0; i5 < 2; i5++)
            {
                switch (i5)
                {
                    case 19:
                        Type_4 v6 = new Type_4();
                        break;
                    case 48:
                        i0 = 95;
                        break;
                    default:
                        Type_0<string> v7 = new Type_0<string>();
                        break;
                }
            }
        }

        for (int i8 = 0; i8 < 3; i8++)
        {
            await System.Threading.Tasks.Task.CompletedTask;
        }

        Console.WriteLine("Trace");
        switch (19)
        {
            case 85:
                if (false)
                {
                    switch ((29) - (21))
                    {
                        case 17:
                            break;
                        case 43:
                            Type_3 v9 = new Type_3();
                            break;
                        default:
                            Type_2 v10 = new Type_2();
                            break;
                    }
                }

                break;
            case 19:
                for (int i11 = 0; i11 < 2; i11++)
                {
                    i11 = 98;
                    if (false)
                    {
                        i11 = 12;
                        Console.WriteLine(i11);
                        Type_3.Type_1 v12 = new Type_3.Type_1();
                    }
                    else
                    {
                        Type_4 v13 = new Type_4();
                        bool v14 = true;
                        bool v15 = true;
                    }
                }

                break;
            case 10:
                break;
            default:
                string v16 = "5ac1cce2";
                break;
        }

        await System.Threading.Tasks.Task.CompletedTask;
        switch (((await System.Threading.Tasks.Task.FromResult(76)) + (8)) - (31))
        {
            case 75:
                for (int i17 = 0; i17 < 4; i17++)
                {
                    for (int i18 = 0; i18 < 2; i18++)
                    {
                        Type_3.Type_1 v19 = new Type_3.Type_1();
                    }

                    Console.WriteLine("Trace 20");
                    for (int i20 = 0; i20 < 4; i20++)
                    {
                        Type_3 v21 = new Type_3()
                        {
                            Prop_0 = false
                        };
                    }
                }

                break;
            case 77:
                for (int i22 = 0; i22 < 2; i22++)
                {
                    await System.Threading.Tasks.Task.CompletedTask;
                    for (int i23 = 0; i23 < 3; i23++)
                    {
                        Console.WriteLine(i22);
                        Type_0<int> v24 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(new Type_0<int>()));
                        string v25 = await System.Threading.Tasks.Task.FromResult("b94fdcb8");
                    }
                }

                break;
            default:
                break;
        }

        await System.Threading.Tasks.Task.CompletedTask;
        if (true)
        {
            Console.WriteLine("Trace");
            for (int i26 = 0; i26 < 3; i26++)
            {
                Console.WriteLine(i26);
            }
        }
        else
        {
            try
            {
                if (await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(true)))
                {
                    Console.WriteLine("Trace 27");
                }

                bool v27 = true;
            }
            catch (NullReferenceException ex28)
            {
                switch ((52) * ((2) * (65)))
                {
                    case 76:
                        Type_4 v29 = new Type_4();
                        break;
                    case 7:
                        bool v30 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(false));
                        string v31 = "9c7e44c0";
                        break;
                    case 87:
                        int v32 = 98;
                        break;
                    default:
                        string v33 = Type_0<bool>.Method_0(new Type_4(), new Type_2(), new Type_2());
                        break;
                }
            }
            finally
            {
                if (true)
                {
                    Type_0<string> v34 = new Type_0<string>();
                    Type_2 v35 = new Type_2();
                }
                else
                {
                    int v36 = 57;
                }
            }
        }

        Console.WriteLine("Trace 37");
        Console.WriteLine("Program End");
    }
}