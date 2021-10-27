using System;
using System.IO;

class Ready
{
    static void Swap(ref int a, ref int b)
    {
        int work = a;
        a = b;
        b = work;
    }

    public static int[] Reshufle()
    {
        int[] work = new int[52];
        for (int i = 0; i < work.Length; i++)
        {
            int a = (i + 4) / 4;
            work[i] = a;
        }
        Random rnd = new Random();
        for (int i = 0; i < work.Length; i++)
        {
            int NextResult = rnd.Next(i, work.Length);
            Swap(ref work[i], ref work[NextResult]);
        }

        return work;
    }
   

}
class Play
{
    int[] hand;//手札
    int[] yama;//山札
    public int th; //山札の何枚目
    public void StartGame()
    {
        yama = Ready.Reshufle();
        hand = new int[3];


        for (int i = 0; i < 2; i++)
        {
            hand[i] = yama[th];
            th++;
        }

        Console.WriteLine("数字を3つ揃えるゲームです。");
        Console.WriteLine("毎ターン1枚、数字を引いて捨てます。");
        Console.WriteLine("52枚の山札が尽きたらゲームオーバー。");
        Console.WriteLine("それまでに、3つ同じ数字を手札に揃えれば勝利です。");
        Console.WriteLine("ゲームスタート！");
    }
    
    public void Draw()
    {
        th++;
        hand[2] = yama[th];
        Console.WriteLine(yama[th] + "を引いた。");
        Console.WriteLine("残り山札は{0}枚です。", (52 - (th+1)));
        Console.Write("手札:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(hand[i]);
            if (i < 2) Console.Write(",");
        }
        Console.WriteLine("\n");

    }
    public void Discard()
    {
        Console.WriteLine("捨てたい数字を入力してください。");
        int[] work = new int[hand.Length];
        int f;
        string str;

        do
        {
            for (; ; )
            {
                str = Console.ReadLine();
                f = Int32.Parse(str);
                if (0 < f & f < 14) break;
            }
            
        }while(f != hand[0] & f != hand[1] & f != hand[2]);

        for (int i = 0; i < hand.Length; i++) {    
            if (hand[i] == f)
            {
                for (int j = 0, a = 0; j < 2; j++, a++)
                {
                    if (i == j) a++;
                    work[j] = hand[a];
                }

                int[] m = new int[3];
                for (int n = 0; n < 3; n++)
                {
                    m[n] = work[n];
                    hand[n] = m[n];
                }
                break;
            }
        }
    }
    public bool Check()
    {
        int i = 0;
        if ((hand[i] == hand[i + 1]) & (hand[i] == hand[i + 2]))
            return true;
        else return false;



    }
}

class Program
{
    static void Main()
    {
        Play a = new Play();
        a.StartGame();
        while(a.th <= 52)
        {
            a.Draw();
            if (a.Check())
            {
                Console.WriteLine("You win!");
                Console.WriteLine("勝利ターン数:" + (a.th / 4));

                break;
            }
            else
            {
                a.th += 3;
                if (a.th >= 52)
                {
                    Console.WriteLine("You Lose...\n--山札がなくなりました。");
                    break;
                }
                a.Discard();
            }

        }
    }
}

