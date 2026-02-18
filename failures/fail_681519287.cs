using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public interface Type_0
{
    Type_0 Prop_0 { get; set; }

    abstract System.Threading.Tasks.Task<int> Method_1(Type_0 p0, Type_3 p1);
}

public struct Type_1
{
    public static string Prop_0 { get; set; }
}

public interface Type_2 : Type_0
{
    Type_0 Prop_0 { get; set; }

    string Prop_1 { get; }

    Type_4 Prop_2 { get; set; }

    System.Threading.Tasks.Task<int> Method_1(Type_0 p0, Type_3 p1);
}

public interface Type_3 : Type_0
{
    Type_0 Prop_0 { get; set; }

    bool Prop_1 { get; set; }

    System.Threading.Tasks.Task<int> Method_1(Type_0 p0, Type_3 p1);
    abstract int Method_2(Type_3 p0);
}

public struct Type_4 : Type_3
{
    public Type_0 Prop_0 { get; set; }
    public bool Prop_1 { get; set; }

    public System.Threading.Tasks.Task<int> Method_1(Type_0 p0, Type_3 p1)
    {
        if (false)
        {
            try
            {
                int v0 = p1.Method_2(default(Type_3));
                for (int i1 = 0; i1 < 3; i1++)
                {
                    Type_0 v2 = default(Type_0);
                    return default(System.Threading.Tasks.Task<int>);
                }

                return p1.Method_1(p0, default(Type_3));
            }
            catch (InvalidOperationException ex3)
            {
                for (int i4 = 0; i4 < 3; i4++)
                {
                    Type_3 v5 = default(Type_3);
                    Type_3 v6 = default(Type_3);
                    Type_2 v7 = default(Type_2);
                    return this.Method_1(p0, default(Type_3));
                }

                return default(System.Threading.Tasks.Task<int>);
            }
            finally
            {
                try
                {
                    Type_2 v8 = default(Type_2);
                    Type_2 v9 = default(Type_2);
                }
                catch (ArgumentException ex10)
                {
                    Console.WriteLine("TraceObj");
                }
                finally
                {
                    int v11 = 59;
                }
            }

            try
            {
                Type_2 v12 = default(Type_2);
                return default(System.Threading.Tasks.Task<int>);
            }
            catch (ArgumentException ex13)
            {
                p1 = p1;
                return default(System.Threading.Tasks.Task<int>);
            }

            return this.Method_1(default(Type_0), default(Type_3));
        }

        bool v14 = true;
        Type_0 v15 = default(Type_0);
        Console.WriteLine("Trace 16");
        return v15.Method_1(default(Type_0), default(Type_3));
    }

    public int Method_2(Type_3 p0)
    {
        try
        {
            if (p0.Prop_1)
            {
                try
                {
                    bool v16 = false;
                    return 90;
                }
                catch (NullReferenceException ex17)
                {
                    int v18 = 4;
                    return (83) + (18);
                }
                finally
                {
                    bool v19 = true;
                }

                return 94;
            }

            if (this.Prop_1)
            {
                if ((default(Type_2)) == (default(Type_2)))
                {
                    Console.WriteLine("Trace 20");
                    Type_2 v20 = default(Type_2);
                    int v21 = 1;
                    return 30;
                }

                return 95;
            }

            return 62;
        }
        catch (NullReferenceException ex22)
        {
            Console.WriteLine("TraceObj");
            return 96;
        }

        for (int i23 = 0; i23 < 2; i23++)
        {
            if (false)
            {
                int v24 = this.Method_2(default(Type_3));
                if ((this.Prop_1) && (false))
                {
                    Type_1 v25 = this.Method_0(("87ed7b90") + ("6d0e20a5"));
                    Console.WriteLine("TraceObj");
                    return (98) + (15);
                }
                else
                {
                    Type_4 v26 = new Type_4()
                    {
                        Prop_1 = this.Prop_1
                    };
                    return 51;
                }

                return (33) * (87);
            }

            switch ((63) * (i23))
            {
                case 50:
                    if (true)
                    {
                        Type_3 v27 = default(Type_3);
                        Type_1 v28 = new Type_1();
                        Type_1 v29 = v28;
                        return this.Method_3(true, default(Type_2), 47);
                    }

                    return (27) - (86);
                    break;
                case 92:
                    if ((false) && (false))
                    {
                        string v30 = (("e2b4ab62") + ("1a76a55e")) + (("ebb7aed2") + ("e300a54a"));
                        string v31 = "046bbb7c";
                        return 82;
                    }

                    string v32 = ("7f2ed82b") + ("d05873fa");
                    return 41;
                    break;
                case 25:
                    int v33 = 60;
                    Type_4 v34 = new Type_4();
                    return 1;
                    break;
                default:
                    Console.WriteLine("Trace 35");
                    return this.Method_3(false, default(Type_2), 21);
                    break;
            }

            switch (37)
            {
                case 30:
                    switch (9)
                    {
                        case 65:
                            Type_4 v35 = new Type_4();
                            p0 = p0;
                            return 79;
                            break;
                        case 13:
                            int v36 = 25;
                            Type_2 v37 = default(Type_2);
                            return 21;
                            break;
                        default:
                            Console.WriteLine(i23);
                            return 87;
                            break;
                    }

                    return i23;
                    break;
                case 17:
                    Type_4 v38 = new Type_4();
                    return (18) - (i23);
                    break;
                case 88:
                    try
                    {
                        int v39 = 20;
                        return v39;
                    }
                    catch (NullReferenceException ex40)
                    {
                        string v41 = ("e3b13798") + ("dafdfdfd");
                        return this.Method_3(true, default(Type_2), 5);
                    }

                    return 91;
                    break;
                default:
                    p0 = default(Type_3);
                    return (83) * (this.Method_3(false, default(Type_2), 44));
                    break;
            }

            return 84;
        }

        Type_1 v42 = new Type_1();
        for (int i43 = 0; i43 < 4; i43++)
        {
            try
            {
                if (true)
                {
                    int v44 = 4;
                    return 65;
                }

                return ((47) + (i43)) - (64);
            }
            catch (InvalidOperationException ex45)
            {
                if (true)
                {
                    Type_1 v46 = v42;
                    Type_3 v47 = default(Type_3);
                    return 57;
                }

                return 18;
            }
            finally
            {
                if (true)
                {
                    int v48 = this.Method_3(true, default(Type_2), 14);
                    Type_1 v49 = new Type_1();
                    bool v50 = false;
                }
                else
                {
                    int v51 = (i43) - (46);
                    Type_0 v52 = default(Type_0);
                }
            }

            for (int i53 = 0; i53 < 4; i53++)
            {
                for (int i54 = 0; i54 < 3; i54++)
                {
                    Type_1 v55 = this.Method_0("66617ea7");
                    i54 = 58;
                    return i43;
                }

                return 79;
            }

            return i43;
        }

        return 61;
    }

    public Type_1 Method_0(string p0)
    {
        p0 = "3a7d3a5a";
        if (true)
        {
            Console.WriteLine(p0);
            Console.WriteLine("Trace 56");
            Type_2 v56 = default(Type_2);
            return new Type_1();
        }
        else
        {
            Console.WriteLine(p0);
            int v57 = 45;
            if (true)
            {
                if (((false) && (true)) && (false))
                {
                    Type_4 v58 = new Type_4();
                    Type_0 v59 = default(Type_0);
                    return new Type_1();
                }

                try
                {
                    Type_3 v60 = default(Type_3);
                    string v61 = ("c4753c68") + ("247fd052");
                    return new Type_1();
                }
                catch (NullReferenceException ex62)
                {
                    string v63 = p0;
                    return this.Method_0("8d54ad96");
                }

                return new Type_1();
            }

            return new Type_1();
        }

        for (int i64 = 0; i64 < 3; i64++)
        {
            switch (i64)
            {
                case 53:
                    Console.WriteLine(p0);
                    int v65 = this.Method_3(this.Prop_1, default(Type_2), this.Method_3((default(Type_2)) == (default(Type_2)), default(Type_2), this.Method_3(true, default(Type_2), 54)));
                    return new Type_1();
                    break;
                case 34:
                    i64 = 0;
                    return new Type_1();
                    break;
                case 55:
                    try
                    {
                        Type_0 v66 = default(Type_0);
                        Type_0 v67 = default(Type_0);
                        return this.Method_0(p0);
                    }
                    catch (ArgumentException ex68)
                    {
                        bool v69 = (this.Prop_1) && ((default(Type_3)) == (default(Type_3)));
                        return new Type_1();
                    }

                    if (false)
                    {
                        Console.WriteLine("Trace 70");
                        return new Type_1();
                    }
                    else
                    {
                        i64 = this.Method_2(default(Type_3));
                        Type_3 v70 = default(Type_3);
                        Type_0 v71 = default(Type_0);
                        return new Type_1();
                    }

                    return new Type_1();
                    break;
                default:
                    i64 = this.Method_3((true) == (true), default(Type_2), this.Method_2(default(Type_3)));
                    return new Type_1();
                    break;
            }

            return new Type_1();
        }

        switch (p0)
        {
            case "328cbd8e":
                p0 = "dc77c801";
                switch (p0)
                {
                    case "774af57f":
                        for (int i72 = 0; i72 < 3; i72++)
                        {
                            Type_4 v73 = this;
                            return new Type_1();
                        }

                        return new Type_1();
                        break;
                    case "828a4adb":
                        try
                        {
                            string v74 = ("40c484ae") + ("63f9438c");
                            return new Type_1();
                        }
                        catch (Exception ex75)
                        {
                            string v76 = "36ca9eef";
                            return new Type_1();
                        }

                        return new Type_1();
                        break;
                    default:
                        Console.WriteLine(p0);
                        return new Type_1();
                        break;
                }

                return new Type_1();
                break;
            case "203476c4":
                bool v77 = false;
                return new Type_1();
                break;
            case "08723765":
                try
                {
                    if (this.Prop_1)
                    {
                        Console.WriteLine("Trace 78");
                        Type_0 v78 = default(Type_0);
                        return new Type_1();
                    }

                    Type_2 v79 = default(Type_2);
                    return new Type_1();
                }
                catch (NullReferenceException ex80)
                {
                    Type_4 v81 = new Type_4();
                    return new Type_1();
                }

                return new Type_1();
                break;
            default:
                if ((true) && (true))
                {
                    switch (p0)
                    {
                        case "072516f0":
                            string v82 = (("6f6e89c5") + (("83481963") + ("3b0d33e6"))) + ("6582eeb5");
                            return this.Method_0(v82);
                            break;
                        case "b752f614":
                            Console.WriteLine("Trace 83");
                            return new Type_1();
                            break;
                        case "47fc192e":
                            string v83 = "a92c1ca0";
                            return new Type_1();
                            break;
                        default:
                            bool v84 = (true) && (false);
                            return new Type_1();
                            break;
                    }

                    return this.Method_0("8f8d58ff");
                }

                return new Type_1();
                break;
        }

        for (int i85 = 0; i85 < 4; i85++)
        {
            Console.WriteLine("Trace 86");
            string v86 = ("6ea7da68") + ("e49c40a3");
            return this.Method_0(("e2d2afc9") + ("797833a0"));
        }

        return new Type_1();
    }

    public int Method_3(bool p0, Type_2 p1, int p2)
    {
        try
        {
            for (int i87 = 0; i87 < 4; i87++)
            {
                for (int i88 = 0; i88 < 2; i88++)
                {
                    i88 = 92;
                    string v89 = "052ce04a";
                    p2 = 43;
                    return (28) + (20);
                }

                try
                {
                    string v90 = "a8c73d63";
                    return 72;
                }
                catch (Exception ex91)
                {
                    Type_3 v92 = default(Type_3);
                    return i87;
                }

                bool v93 = (default(Type_3)) == (default(Type_3));
                return this.Method_3((i87) < (93), default(Type_2), 42);
            }

            return 61;
        }
        catch (Exception ex94)
        {
            for (int i95 = 0; i95 < 4; i95++)
            {
                i95 = 22;
                string v96 = Type_1.Prop_0;
                Type_3 v97 = default(Type_3);
                return this.Method_3(v97.Prop_1, p1, 71);
            }

            return p2;
        }
        finally
        {
            Type_2 v98 = default(Type_2);
        }

        int v99 = this.Method_3(false, default(Type_2), this.Method_2(default(Type_3)));
        try
        {
            try
            {
                for (int i100 = 0; i100 < 3; i100++)
                {
                    bool v101 = true;
                    bool v102 = false;
                    return 70;
                }

                return 53;
            }
            catch (Exception ex103)
            {
                if (false)
                {
                    Type_0 v104 = this.Prop_0;
                    Type_0 v105 = default(Type_0);
                    return 77;
                }

                return (13) + (42);
            }

            return 98;
        }
        catch (Exception ex106)
        {
            switch (67)
            {
                case 17:
                    switch (p2)
                    {
                        case 10:
                            string v107 = ("9e0f748c") + (("1f83e6a0") + ("fa2994cb"));
                            return 92;
                            break;
                        case 39:
                            Console.WriteLine("Trace 108");
                            return v99;
                            break;
                        default:
                            string v108 = "b8d3af68";
                            return 56;
                            break;
                    }

                    return v99;
                    break;
                case 70:
                    Console.WriteLine("TraceObj");
                    return 11;
                    break;
                default:
                    try
                    {
                        Type_1 v109 = new Type_1();
                        return 23;
                    }
                    catch (InvalidOperationException ex110)
                    {
                        bool v111 = false;
                        return (v99) * (v99);
                    }
                    finally
                    {
                        int v112 = (67) * ((this.Method_2(default(Type_3))) + (44));
                    }

                    return 96;
                    break;
            }

            return this.Method_3(false, default(Type_2), 24);
        }

        try
        {
            Console.WriteLine("Trace 113");
            Type_1 v113 = new Type_1();
            return this.Method_3(true, default(Type_2), p2);
        }
        catch (ArgumentException ex114)
        {
            p0 = false;
            return p2;
        }
        finally
        {
            Type_1 v115 = new Type_1();
        }

        try
        {
            if (false)
            {
                try
                {
                    Type_2 v116 = default(Type_2);
                    return 34;
                }
                catch (InvalidOperationException ex117)
                {
                    return 98;
                }
                finally
                {
                    Type_0 v118 = default(Type_0);
                }

                return 23;
            }
            else
            {
                Console.WriteLine(p0);
                return 98;
            }

            return this.Method_2(default(Type_3));
        }
        catch (InvalidOperationException ex119)
        {
            switch (74)
            {
                case 66:
                    Type_4 v120 = this;
                    Type_1 v121 = new Type_1();
                    return v120.Method_2(default(Type_3));
                    break;
                case 8:
                    bool v122 = this.Prop_1;
                    p2 = 81;
                    return v99;
                    break;
                default:
                    switch (p2)
                    {
                        case 39:
                            Console.WriteLine("TraceObj");
                            return (79) + (95);
                            break;
                        case 89:
                            bool v123 = false;
                            p2 = 1;
                            return 23;
                            break;
                        case 22:
                            Type_3 v124 = default(Type_3);
                            return 24;
                            break;
                        default:
                            Type_4 v125 = p1.Prop_2;
                            return (v99) - (v99);
                            break;
                    }

                    return v99;
                    break;
            }

            return 29;
        }

        return (p2) - (17);
    }
}

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Program Start");
        try
        {
            if ((await System.Threading.Tasks.Task.FromResult(default(Type_0))) == (default(Type_0)))
            {
                await System.Threading.Tasks.Task.CompletedTask;
                await System.Threading.Tasks.Task.CompletedTask;
            }
            else
            {
                for (int i0 = 0; i0 < 3; i0++)
                {
                    Type_3 v1 = default(Type_3);
                    int v2 = 87;
                }

                Type_1 v3 = await System.Threading.Tasks.Task.FromResult(new Type_1());
            }
        }
        catch (ArgumentException ex4)
        {
            for (int i5 = 0; i5 < 2; i5++)
            {
                i5 = 76;
                await System.Threading.Tasks.Task.CompletedTask;
            }
        }

        Type_4 v6 = new Type_4();
        await System.Threading.Tasks.Task.CompletedTask;
        await System.Threading.Tasks.Task.CompletedTask;
        try
        {
            Console.WriteLine("TraceObj");
            string v7 = await System.Threading.Tasks.Task.FromResult("9b297dc6");
        }
        catch (Exception ex8)
        {
            await System.Threading.Tasks.Task.CompletedTask;
        }

        try
        {
            switch ((5) - (14))
            {
                case 36:
                    if (v6.Prop_1)
                    {
                        int v9 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(4));
                    }
                    else
                    {
                        bool v10 = await System.Threading.Tasks.Task.FromResult(true);
                        int v11 = v6.Method_2(default(Type_3));
                    }

                    await System.Threading.Tasks.Task.CompletedTask;
                    break;
                case 95:
                    try
                    {
                        bool v12 = true;
                    }
                    catch (Exception ex13)
                    {
                        Console.WriteLine("TraceObj");
                    }

                    try
                    {
                        v6 = new Type_4();
                        Type_1 v14 = new Type_1();
                    }
                    catch (InvalidOperationException ex15)
                    {
                        int v16 = (12) - (v6.Method_3(true, default(Type_2), ((44) - (31)) + ((44) * (0))));
                    }

                    break;
                case 57:
                    try
                    {
                        Type_2 v17 = default(Type_2);
                        Console.WriteLine("Trace 18");
                    }
                    catch (Exception ex18)
                    {
                        v6 = new Type_4();
                    }

                    break;
                default:
                    try
                    {
                        string v19 = ("ad4cc205") + (await System.Threading.Tasks.Task.FromResult("c86fc0c9"));
                    }
                    catch (NullReferenceException ex20)
                    {
                        int v21 = 61;
                    }

                    break;
            }
        }
        catch (NullReferenceException ex22)
        {
            Console.WriteLine("TraceObj");
        }

        await System.Threading.Tasks.Task.CompletedTask;
        switch (29)
        {
            case 12:
                for (int i23 = 0; i23 < 2; i23++)
                {
                    Console.WriteLine("TraceObj");
                    Type_3 v24 = await System.Threading.Tasks.Task.FromResult(default(Type_3));
                }

                if (false)
                {
                    switch (await System.Threading.Tasks.Task.FromResult(71))
                    {
                        case 50:
                            Type_0 v25 = await await System.Threading.Tasks.Task.FromResult(System.Threading.Tasks.Task.FromResult(default(Type_0)));
                            break;
                        case 26:
                            int v26 = (v6.Method_2(default(Type_3))) * ((41) - (63));
                            v26 = v26;
                            break;
                        case 23:
                            Type_2 v27 = default(Type_2);
                            break;
                        default:
                            int v28 = 59;
                            break;
                    }

                    await System.Threading.Tasks.Task.CompletedTask;
                    if (v6.Prop_1)
                    {
                        int v29 = 10;
                    }
                }
                else
                {
                    for (int i30 = 0; i30 < 2; i30++)
                    {
                        string v31 = "74765442";
                        Type_3 v32 = default(Type_3);
                        Type_4 v33 = new Type_4();
                    }

                    Type_4 v34 = new Type_4();
                }

                break;
            case 89:
                Type_0 v35 = default(Type_0);
                break;
            case 95:
                switch (57)
                {
                    case 12:
                        Type_0 v36 = default(Type_0);
                        switch (v6.Method_2(await System.Threading.Tasks.Task.FromResult(default(Type_3))))
                        {
                            case 4:
                                v36 = await System.Threading.Tasks.Task.FromResult(default(Type_0));
                                Type_2 v37 = default(Type_2);
                                break;
                            case 26:
                                string v38 = ("17193f14") + ("72ea9718");
                                bool v39 = true;
                                break;
                            default:
                                Console.WriteLine("Trace 40");
                                break;
                        }

                        break;
                    case 27:
                        v6 = v6;
                        Console.WriteLine("Trace 40");
                        break;
                    default:
                        try
                        {
                            v6 = await System.Threading.Tasks.Task.FromResult(new Type_4());
                        }
                        catch (ArgumentException ex40)
                        {
                            int v41 = 51;
                        }

                        break;
                }

                if (((default(Type_3)) == (default(Type_3))) && (v6.Prop_1))
                {
                    if ((true) && (false))
                    {
                        Type_1 v42 = new Type_1();
                        int v43 = await System.Threading.Tasks.Task.FromResult(33);
                    }
                    else
                    {
                        string v44 = await System.Threading.Tasks.Task.FromResult("03da9ade");
                        Type_1 v45 = v6.Method_0(v44);
                    }
                }
                else
                {
                    Type_1 v46 = await System.Threading.Tasks.Task.FromResult(new Type_1());
                    Console.WriteLine("TraceObj");
                }

                break;
            default:
                Console.WriteLine("Trace 47");
                break;
        }

        bool v47 = (await System.Threading.Tasks.Task.FromResult(false)) && (("66d8487c") == (await System.Threading.Tasks.Task.FromResult("803d2e64")));
        v6 = new Type_4();
        Console.WriteLine("Program End");
    }
}