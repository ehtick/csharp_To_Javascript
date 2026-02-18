using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public interface Type_0<T0, T1>
{
    int Prop_0 { get; }

    Type_0<int, bool> Prop_1 { get; set; }

    Type_4 Prop_2 { get; set; }
}

public interface Type_1
{
    int Prop_1 { get; set; }

    abstract Type_4 Method_0(Type_1 p0, Type_1 p1);
}

public interface Type_2
{
    abstract Type_3<bool, string> Method_0(bool p0, string p1);
}

public interface Type_3<T0, T1>
{
    Type_1 Prop_0 { get; }

    abstract string Method_1(string p0, string p1, Type_2 p2);
}

public interface Type_4
{
    string Prop_1 { get; }

    abstract bool Method_0(string p0, Type_3<string, string> p1);
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        try
        {
            await System.Threading.Tasks.Task.Yield();
        }
        catch (InvalidOperationException ex0)
        {
            if (false)
            {
                if (await System.Threading.Tasks.Task.FromResult(true))
                {
                    Console.WriteLine("Trace 1");
                    Console.WriteLine("Trace");
                    bool v1 = true;
                }

                Type_4 v2 = default(Type_4);
            }
            else
            {
                Type_1 v3 = await System.Threading.Tasks.Task.FromResult(default(Type_1));
                Console.WriteLine("TraceObj");
                Console.WriteLine("Trace 4");
            }
        }

        switch (3)
        {
            case 24:
                if (true)
                {
                }

                break;
            case 29:
                bool v4 = true;
                for (int i5 = 0; i5 < 2; i5++)
                {
                    for (int i6 = 0; i6 < 3; i6++)
                    {
                        Type_2 v7 = default(Type_2);
                        Type_1 v8 = default(Type_1);
                    }

                    try
                    {
                        Type_0<bool, bool> v9 = default(Type_0<bool, bool>);
                        Console.WriteLine(i5);
                    }
                    catch (NullReferenceException ex10)
                    {
                        string v11 = "5aee932d";
                    }
                    finally
                    {
                        Type_3<string, string> v12 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(default(Type_3<string, string>)));
                    }
                }

                break;
            case 18:
                bool v13 = await System.Threading.Tasks.Task.FromResult(false);
                for (int i14 = 0; i14 < 4; i14++)
                {
                    if (await System.Threading.Tasks.Task.FromResult(true))
                    {
                        bool v15 = false;
                    }
                    else
                    {
                        Type_3<bool, int> v16 = default(Type_3<bool, int>);
                        string v17 = v16.Method_1(await System.Threading.Tasks.Task.FromResult("b0c2442c"), (v16.Method_1("430ec9dd", "4d97aa4b", default(Type_2))) + (("62156800") + (v16.Method_1("be66eb37", "e170dc20", default(Type_2)))), default(Type_2));
                    }

                    switch (await System.Threading.Tasks.Task.FromResult(15))
                    {
                        case 27:
                            Console.WriteLine("Trace 18");
                            break;
                        case 9:
                            string v18 = "138b8a30";
                            bool v19 = false;
                            break;
                        default:
                            v13 = false;
                            break;
                    }

                    if (false)
                    {
                        i14 = ((27) * (await System.Threading.Tasks.Task.FromResult(38))) + (95);
                        Console.WriteLine(v13);
                    }
                    else
                    {
                        Type_0<int, string> v20 = default(Type_0<int, string>);
                        string v21 = "60499939";
                        bool v22 = (true) && (await System.Threading.Tasks.Task.FromResult(true));
                    }
                }

                break;
            default:
                await System.Threading.Tasks.Task.Yield();
                break;
        }

        try
        {
            if (true)
            {
                if (false)
                {
                }
                else
                {
                    bool v23 = false;
                    string v24 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult("48602c68"));
                }
            }
            else
            {
                try
                {
                }
                catch (Exception ex25)
                {
                    bool v26 = false;
                }
            }
        }
        catch (InvalidOperationException ex27)
        {
            if (await System.Threading.Tasks.Task.FromResult(false))
            {
                Console.WriteLine("Trace");
                for (int i28 = 0; i28 < 2; i28++)
                {
                    string v29 = "cc4dc610";
                }
            }
        }
        finally
        {
            Console.WriteLine("Trace");
        }

        bool v30 = true;
        v30 = (default(Type_2)) == (default(Type_2));
        for (int i31 = 0; i31 < 4; i31++)
        {
            Type_0<string, string> v32 = default(Type_0<string, string>);
            try
            {
                await System.Threading.Tasks.Task.Yield();
            }
            catch (InvalidOperationException ex33)
            {
                switch (v32.Prop_0)
                {
                    case 23:
                        int v34 = 37;
                        break;
                    case 63:
                        Type_3<int, string> v35 = default(Type_3<int, string>);
                        string v36 = "ef486d7c";
                        break;
                    default:
                        Type_2 v37 = await System.Threading.Tasks.Task.FromResult(default(Type_2));
                        break;
                }
            }
        }

        try
        {
            switch (1)
            {
                case 75:
                    v30 = false;
                    bool v38 = await await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(false)));
                    break;
                case 71:
                    v30 = false;
                    for (int i39 = 0; i39 < 3; i39++)
                    {
                        bool v40 = v30;
                        bool v41 = ((default(Type_2)) == (await System.Threading.Tasks.Task.FromResult(default(Type_2)))) && ((default(Type_3<bool, int>)) == (default(Type_3<bool, int>)));
                        string v42 = "e2739cf7";
                    }

                    break;
                case 46:
                    v30 = true;
                    break;
                default:
                    try
                    {
                        int v43 = 97;
                        Console.WriteLine("Trace 44");
                    }
                    catch (Exception ex44)
                    {
                        Console.WriteLine("Trace 45");
                    }

                    break;
            }
        }
        catch (ArgumentException ex45)
        {
            v30 = v30;
        }

        for (int i46 = 0; i46 < 3; i46++)
        {
            if (true)
            {
                await System.Threading.Tasks.Task.Yield();
            }
            else
            {
                i46 = i46;
                for (int i47 = 0; i47 < 4; i47++)
                {
                    string v48 = "02642c4b";
                    Console.WriteLine(i46);
                    Type_4 v49 = default(Type_4);
                }

                Console.WriteLine(v30);
            }

            await System.Threading.Tasks.Task.CompletedTask;
            v30 = await System.Threading.Tasks.Task.FromResult(true);
        }

        v30 = v30;
        Console.WriteLine("Program End");
    }
}