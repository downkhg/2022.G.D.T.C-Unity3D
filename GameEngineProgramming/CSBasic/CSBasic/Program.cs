using System;
using System.Collections.Generic;

namespace CSBasic
{
    class Player
    {
        public string strName;
        public int nHP;
        public int nDemage;
        public Player(string name, int hp, int dem)
        {
            strName = name;
            nHP = hp;
            nDemage = dem;
        }
        public void Attack(Player target)
        {
            target.nHP = target.nHP - this.nDemage;
        }
        public bool Death()
        {
            if (nHP > 0)
                return false;
            else
                return true;
        }
        public void Display(string msg)
        {
            Console.WriteLine("##### " + msg + " #######");
            Console.WriteLine("Name:" + strName);
            Console.WriteLine("Demage:" + nDemage);
            Console.WriteLine("HP:" + nHP);
            Console.WriteLine("###################");
        }
    }

    class Program
    {
        //객체: 몬스터와 플레이어의 객체(클래스)는 같다.
        //인스턴스: 몬스터 플레이어와 인스턴스는 다르다.(능력치나 이름이 다르다)
        static void OPPBattilMain()
        {
            Player cPlayer = new Player("player", 100, 10);
            Player cMonster = new Player("monster", 100, 10);

            cPlayer.Attack(cMonster);
            cMonster.Attack(cPlayer);
        }

        static void RPGMain()
        {
            Player sPlayer = new Player("player", 100, 10);

            List<Player> listMonsters = new List<Player>();
            listMonsters.Add(new Player("slime", 100, 10));
            listMonsters.Add(new Player("skeleton", 100, 10));
            listMonsters.Add(new Player("zombie", 100, 10));
            listMonsters.Add(new Player("dragon", 100, 10));

            while (true)
            {
                for (int i = 0; i < listMonsters.Count; i++)
                {
                    Console.WriteLine("[" + i + "]:" + listMonsters[i].strName);
                }
                int nIdx = int.Parse(Console.ReadLine());
                Console.WriteLine("Idx:" + nIdx);

                if (nIdx >= 0 && nIdx < listMonsters.Count) // 0 < idx < conut
                {
                    Player sMonster = listMonsters[nIdx];

                    Battle(sPlayer, sMonster);
                    //Battle(sPlayer.nDemage, sPlayer.nHP, sMonster.nDemage, sMonster.nHP);
                }
                else
                {
                    Console.WriteLine("Exit");
                    break;
                }
            }

        }

        static void Battle(Player player, Player monster)
        {
            while (true)
            {
                if (player.Death() == false)
                {
                    player.Attack(monster);
                    monster.Display("Player Attack!");
                }
                else
                {
                    Console.WriteLine(monster.strName + " Win!");
                    break;
                }
                if (monster.Death() == false)
                {
                    monster.Attack(player);
                    player.Display("Monster Attack!");
                }
                else
                {
                    Console.WriteLine(player.strName + " Win!");
                    break;
                }
            }
        }

        //Ctrl+f5
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.WriteLine("Test");
            //Console.WriteLine("Add:" + Add(10, 20));
            //ValMain(); //함수의 호출
            //PlayerAttackMain();
            //PlayerCritcalAttackMain();
            //StageMain();
            //PlayerAttackWhileMain();
            RPGMain();
        }

        static int Add(int a, int b)//10, 20
        {
            int c = a + b; //30
            return c; //30
        }
        //각 예제 별로 1개씩 실행해보고 결과 확인하기
        static void ValMain()
        {
            //코드보고작성하기
            int nScore = 0;
            float fRat = 1.0f / 4.0f;
            Console.WriteLine("Score:" + nScore);
            Console.WriteLine("Rat:" + fRat);
        }

        static void PlayerAttackMain()
        {
            //플레이어가 몬스터를 공격한다. //공격? 데미지를 준다.
            //플레이어가 몬스터에게 데미지를 준다. //어떻게? 
            //플레이어의 (공격력)만큼 몬스터에게 (hp)를 감소한다.
            //데이터: 공격력, hp
            //알고리즘: 공격 -> hp - 공격력 = hp
            int nAtk = 10;
            int nHp = 100;
            //모든변수들을 연산전과 후로 나누어 출력해야 확인이 가능하다.
            Console.WriteLine("HP:" + nHp + ",Atk:" + nAtk);
            nHp = nHp - nAtk;
            Console.WriteLine("HP:" + nHp + ",Atk:" + nAtk);
        }

        //크리티컬 데미지 추가하기
        //크리티컬 데미지를 일정확확률
        //크리티컬 데이미를 추가한다

        static void PlayerCritcalAttackMain()
        {
            //플이어가 몬스터를 일정확률 추가데미지를 고한다
            //n개의 물건중에 1번에 1개를 뽑을 확률
            Random cRandom = new Random();
            int nRandom = cRandom.Next(1, 3);
            //플레이어가 몬스터를 공격한다. //공격? 데미지를 준다.
            //플레이어가 몬스터에게 데미지를 준다. //어떻게? 
            //플레이어의 (공격력)만큼 몬스터에게 (hp)를 감소한다.
            //데이터: 공격력, hp
            //알고리즘: 공격 -> hp - 공격력 = hp
            int nAtk = 10;
            int nHp = 100;

            Console.WriteLine("Random:" + nRandom);
            Console.WriteLine("HP:" + nHp + ",Atk:" + nAtk);
            if (nRandom == 1)
            { //모든변수들을 연산전과 후로 나누어 출력해야 확인이 가능하다.
                nHp = (int)((float)nHp - (float)(nAtk * 1.5f));
                Console.WriteLine("Critical!!");
            }
            else
                nHp = nHp - nAtk;
            Console.WriteLine("HP:" + nHp + ",Atk:" + nAtk);
        }

        static void StageMain()
        {
            string strInput;
            Console.WriteLine("가고싶은곳을 선택하세요!(마을,상점,필드)");
            strInput = Console.ReadLine();
            //Console.WriteLine(strInput + " 입니다."); //잘못입력한경우 정상적인 출력이 아님.
            //if (strInput == "마을")
            //    Console.WriteLine("마을 입니다.");
            //else if (strInput == "상점")
            //    Console.WriteLine("상점 입니다.");
            //else if (strInput == "필드")
            //    Console.WriteLine("필드 입니다.");
            //else
            //    Console.WriteLine("!?!?!?!?!?");
            switch (strInput)
            {
                case "마을":
                    Console.WriteLine(strInput + " 입니다.");
                    break;
                case "상점":
                    Console.WriteLine(strInput + " 입니다.");
                    break;
                case "필드":
                    Console.WriteLine(strInput + " 입니다.");
                    break;
                default:
                    Console.WriteLine("!?!?!?!?!?");
                    break;
            }
        }
        //플레이어가 몬스터를 공격한다.
        //플레이어가 몬스터가 사망할때까지 공격한다.
        //사망?
        //hp가 0이하일때 공격을 그만한다.
        //hp가 0이 아니면 공격한다.
        //처음부터 컴퓨터에 맞게 생각하는것이 아니라,
        //인간의 사고과정 (무한루프+브레이크)
        //컴퓨터의 사고과정 (인간의 사고과정에 반대를 반복문의 조건으로)
        static void PlayerAttackWhileMain()
        {
            int nAtk = 10;
            int nHp = 100;

            while (nHp > 0) // 100 <= 0 -> F
            //while(true)
            {
                //if (nHp <= 0) break; 
                //모든변수들을 연산전과 후로 나누어 출력해야 확인이 가능하다.
                Console.WriteLine("HP:" + nHp + ",Atk:" + nAtk);
                nHp = nHp - nAtk;
                Console.WriteLine("HP:" + nHp + ",Atk:" + nAtk);
            }
        }
        //플레이어와 몬스터가 서로 공격하게 만들기
        //플레이어가 공격하면 몬스터의 hp가 감소한다.
        //몬스터가 플레이어를 공격하면 플레이어의 hp를 감소한다.
        static void BattleMain()
        {
            int nPlayerAtk = 10;
            int nMonsterHp = 100;

            int nMonsterAtk = 10;
            int nPlayerHp = 100;

            while (nMonsterHp > 0) // 100 <= 0 -> F
            //while(true)
            {
                //if (nHp <= 0) break; 
                //모든변수들을 연산전과 후로 나누어 출력해야 확인이 가능하다.
                Console.WriteLine("HP:" + nMonsterHp + ",Atk:" + nPlayerAtk);
                nMonsterHp = nMonsterHp - nPlayerAtk;
                Console.WriteLine("HP:" + nMonsterHp + ",Atk:" + nPlayerAtk);
            }
        }
    }
}
