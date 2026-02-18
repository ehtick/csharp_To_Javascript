using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public interface Type_0
{
    int Prop_1 { get; }

    abstract string Method_0(Type_4.Type_2 p0, bool p1, bool p2);
}

public abstract class Type_1
{
    public string Prop_0 { get; set; }
    public static int Prop_1 { get; set; }
}

public interface Type_3
{
    Type_1 Prop_1 { get; set; }

    abstract System.Threading.Tasks.Task<int> Method_0();
    abstract Type_3 Method_2();
}

public struct Type_4
{
    public async System.Threading.Tasks.Task<Type_3> Method_0()
    {
        try
        {
            if (await System.Threading.Tasks.Task.FromResult(true))
            {
                await System.Threading.Tasks.Task.CompletedTask;
                try
                {
                    int v0 = ((70) + (8)) - ((69) * (await System.Threading.Tasks.Task.FromResult(7)));
                    Type_0 v1 = default(Type_0);
                    return await System.Threading.Tasks.Task.FromResult(default(System.Threading.Tasks.Task<Type_3>));
                }
                catch (InvalidOperationException ex2)
                {
                    Type_0 v3 = default(Type_0);
                    return default(System.Threading.Tasks.Task<Type_3>);
                }
                finally
                {
                    Console.WriteLine("Trace 4");
                }

                return await System.Threading.Tasks.Task.FromResult(default(System.Threading.Tasks.Task<Type_3>));
            }

            return this.Method_0();
        }
        catch (InvalidOperationException ex4)
        {
            try
            {
                return this.Method_0();
            }
            catch (ArgumentException ex5)
            {
                Type_1 v6 = default(Type_1);
                return default(System.Threading.Tasks.Task<Type_3>);
            }

            return await System.Threading.Tasks.Task.FromResult(default(System.Threading.Tasks.Task<Type_3>));
        }

        Type_3 v7 = default(Type_3);
        await System.Threading.Tasks.Task.CompletedTask;
        for (int i8 = 0; i8 < 2; i8++)
        {
            switch (27)
            {
                case 17:
                    switch ((55) + (90))
                    {
                        case 59:
                            int v9 = 54;
                            return default(System.Threading.Tasks.Task<Type_3>);
                            break;
                        case 76:
                            Type_4.Type_2 v10 = default(Type_4.Type_2);
                            return await System.Threading.Tasks.Task.FromResult(default(System.Threading.Tasks.Task<Type_3>));
                            break;
                        default:
                            bool v11 = false;
                            return this.Method_0();
                            break;
                    }

                    v7 = default(Type_3);
                    return default(System.Threading.Tasks.Task<Type_3>);
                    break;
                case 3:
                    Console.WriteLine("Trace 12");
                    Type_4.Type_2 v12 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(default(Type_4.Type_2)));
                    return default(System.Threading.Tasks.Task<Type_3>);
                    break;
                case 91:
                    string v13 = ("f95c8005") + (await System.Threading.Tasks.Task.FromResult("c96bc2c4"));
                    v7 = v7;
                    return this.Method_0();
                    break;
                default:
                    Console.WriteLine(i8);
                    return this.Method_0();
                    break;
            }

            return default(System.Threading.Tasks.Task<Type_3>);
        }

        return this.Method_0();
    }

    public interface Type_2
    {
        bool Prop_3 { get; set; }

        abstract bool Method_0();
        abstract Type_3 Method_1(Type_3 p0);
        abstract int Method_2(int p0, Type_4.Type_2 p1);
    }
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        if (false)
        {
            try
            {
                string v0 = "45b36599";
                switch (v0)
                {
                    case "df19ac66":
                        bool v1 = await System.Threading.Tasks.Task.FromResult(false);
                        break;
                    case "c8dac606":
                        bool v2 = await System.Threading.Tasks.Task.FromResult(true);
                        bool v3 = false;
                        break;
                    default:
                        Type_4.Type_2 v4 = default(Type_4.Type_2);
                        break;
                }
            }
            catch (NullReferenceException ex5)
            {
                for (int i6 = 0; i6 < 4; i6++)
                {
                    int v7 = (3) * (17);
                }
            }
            finally
            {
                Console.WriteLine("Trace 8");
            }

            for (int i8 = 0; i8 < 3; i8++)
            {
                for (int i9 = 0; i9 < 2; i9++)
                {
                    string v10 = "25c87088";
                }
            }
        }

        await System.Threading.Tasks.Task.CompletedTask;
        Console.WriteLine("Trace");
        await System.Threading.Tasks.Task.CompletedTask;
        for (int i11 = 0; i11 < 3; i11++)
        {
            switch (i11)
            {
                case 41:
                    switch (i11)
                    {
                        case 83:
                            Type_0 v12 = default(Type_0);
                            Type_1 v13 = default(Type_1);
                            break;
                        case 26:
                            string v14 = "f71a20f2";
                            break;
                        default:
                            int v15 = (i11) - (94);
                            break;
                    }

                    break;
                case 5:
                    i11 = 36;
                    break;
                default:
                    if (false)
                    {
                        Type_0 v16 = await System.Threading.Tasks.Task.FromResult(default(Type_0));
                        i11 = v16.Prop_1;
                    }
                    else
                    {
                        Type_3 v17 = default(Type_3);
                    }

                    break;
            }

            try
            {
                switch (i11)
                {
                    case 67:
                        int v18 = 51;
                        Type_0 v19 = default(Type_0);
                        break;
                    case 55:
                        Console.WriteLine("Trace 20");
                        break;
                    default:
                        bool v20 = await System.Threading.Tasks.Task.FromResult(true);
                        break;
                }

                try
                {
                    Type_1 v21 = default(Type_1);
                    Type_1 v22 = default(Type_1);
                }
                catch (ArgumentException ex23)
                {
                    bool v24 = true;
                }
            }
            catch (Exception ex25)
            {
                Console.WriteLine("Trace 26");
            }

            if (false)
            {
                if (true)
                {
                    Type_4 v26 = new Type_4();
                    Type_4.Type_2 v27 = default(Type_4.Type_2);
                }

                await System.Threading.Tasks.Task.CompletedTask;
                Console.WriteLine(i11);
            }
            else
            {
                switch (i11)
                {
                    case 35:
                        Console.WriteLine(i11);
                        Type_0 v28 = default(Type_0);
                        break;
                    case 76:
                        Type_3 v29 = default(Type_3);
                        Console.WriteLine(i11);
                        break;
                    default:
                        bool v30 = (true) && (await System.Threading.Tasks.Task.FromResult(false));
                        break;
                }

                i11 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(11));
                i11 = i11;
            }
        }

        for (int i31 = 0; i31 < 2; i31++)
        {
            switch (i31)
            {
                case 19:
                    switch (i31)
                    {
                        case 0:
                            i31 = await System.Threading.Tasks.Task.FromResult(90);
                            Type_0 v32 = await await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(default(Type_0))));
                            break;
                        case 89:
                            Type_4 v33 = new Type_4();
                            break;
                        default:
                            int v34 = 37;
                            break;
                    }

                    break;
                case 6:
                    if (await System.Threading.Tasks.Task.FromResult(true))
                    {
                        Type_0 v35 = default(Type_0);
                        string v36 = v35.Method_0(default(Type_4.Type_2), true, await System.Threading.Tasks.Task.FromResult(false));
                        Type_3 v37 = default(Type_3);
                    }

                    await System.Threading.Tasks.Task.CompletedTask;
                    break;
                case 95:
                    int v38 = 65;
                    for (int i39 = 0; i39 < 3; i39++)
                    {
                        bool v40 = false;
                    }

                    break;
                default:
                    switch (i31)
                    {
                        case 31:
                            Type_0 v41 = default(Type_0);
                            Type_0 v42 = default(Type_0);
                            break;
                        case 11:
                            Type_1 v43 = default(Type_1);
                            break;
                        default:
                            Type_0 v44 = default(Type_0);
                            break;
                    }

                    break;
            }

            if (false)
            {
                await System.Threading.Tasks.Task.CompletedTask;
            }

            i31 = 8;
        }

        Type_3 v45 = default(Type_3);
        Type_4.Type_2 v46 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(default(Type_4.Type_2)));
        try
        {
            switch ((99) * (v46.Method_2(61, default(Type_4.Type_2))))
            {
                case 3:
                    switch ((v46.Method_2(Type_1.Prop_1, default(Type_4.Type_2))) * (11))
                    {
                        case 22:
                            string v47 = "7cf124ac";
                            break;
                        case 29:
                            Type_3 v48 = default(Type_3);
                            string v49 = "11956820";
                            break;
                        case 47:
                            v45 = v45;
                            v45 = default(Type_3);
                            break;
                        default:
                            v45 = v45;
                            break;
                    }

                    switch (29)
                    {
                        case 28:
                            Console.WriteLine("TraceObj");
                            break;
                        case 79:
                            Console.WriteLine("TraceObj");
                            break;
                        default:
                            Type_4 v50 = new Type_4();
                            break;
                    }

                    break;
                case 87:
                    for (int i51 = 0; i51 < 3; i51++)
                    {
                        Console.WriteLine("TraceObj");
                        Type_4.Type_2 v52 = default(Type_4.Type_2);
                        Type_4.Type_2 v53 = default(Type_4.Type_2);
                    }

                    break;
                default:
                    await System.Threading.Tasks.Task.CompletedTask;
                    break;
            }

            Console.WriteLine("TraceObj");
        }
        catch (InvalidOperationException ex54)
        {
            try
            {
                try
                {
                    string v55 = await System.Threading.Tasks.Task.FromResult("6596e65b");
                }
                catch (NullReferenceException ex56)
                {
                    Type_4 v57 = new Type_4();
                }
                finally
                {
                    Type_4.Type_2 v58 = default(Type_4.Type_2);
                }

                if (true)
                {
                    bool v59 = true;
                    Console.WriteLine("TraceObj");
                }
            }
            catch (ArgumentException ex60)
            {
                switch ((71) * ((86) * (Type_1.Prop_1)))
                {
                    case 54:
                        bool v61 = false;
                        int v62 = ((40) + (13)) + (await System.Threading.Tasks.Task.FromResult(69));
                        break;
                    case 60:
                        Type_4 v63 = new Type_4();
                        break;
                    case 17:
                        Type_0 v64 = default(Type_0);
                        break;
                    default:
                        Console.WriteLine("Trace 65");
                        break;
                }
            }
        }

        v46 = default(Type_4.Type_2);
        Console.WriteLine("Program End");
    }
}