using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TallerPractico1_CritterCombat
{
    class Program
    {
        static void Main(string[] args)
        {


            //-----------Aca se llaman a los metodos ------------------------------------------------------

             //AttackSkillPowerReview()

            //SupportSkillPowerReview();

            //DwndSpeedReview();

            // DefenseUpReview();

            // CombatEarthFireReview();

            //CombatWindWaterReview();

            CombatSimulator();

            //---------------------------------------------------------------------------------------------------

            /*
               player1.EquipCritters(1);
             player2.EquipCritters(1);
            AttackSkill askil = new AttackSkill("x",0,0);


            if (player1.Critters[0].Moveset[0] is AttackSkill)
            {
                askil = player1.Critters[0].Moveset[0] as AttackSkill;
                player2.Critters[0].OnHit(player1.Critters[0].BaseAttack, askil.Power, 2);
            }
            player2.Critters.Add(player1.Critters[0]);
            player1.Critters.Remove(player1.Critters[0]);

            Console.WriteLine("Los movimientos del criter son: " + player2.Critters[1].Name);
            
            */
        }

       static public void AttackSkillPowerReview()
        {
            //Un AttackSkill NO puede crearse con poder 0, ni con un valor fuera del rango.
            AttackSkill attackSkill1 = new AttackSkill("pancho Power", 0, 3); // lo sobre cargamos ocn un cero en la parte del poder para probar
            Console.WriteLine("poder del Ataque 1 : " + attackSkill1.Power); //imprimimos el poder para probar
                                                                             //se comprueba que da uno aunque pongamos cero

            //revisamos el caso contrario
            AttackSkill attackSkill2 = new AttackSkill("pancho Power", 25, 3); // la sobrecargamos con un valor por fuera del rango de poder
            Console.WriteLine("poder del Ataque 2: " + attackSkill2.Power); //imprimimos para revisar
            //se comprueba que el valor se ajusta a 10 que es el maximo
        }

        static public void SupportSkillPowerReview()
        {
            //generamos un skill de support para comfirmar
            SupportSkill newSkill = new SupportSkill("x", 10, 0);
            Console.WriteLine("poder del Ataque de support : " + newSkill.Power);
            //El resultaod dio cero comprobamos que cumple
        }

        static public void DwndSpeedReview()
        {
            
            SupportSkill dwnSpeed = new SupportSkill("X", 10, 2); //creamos un ataque de reducir velocidad por facilidad con el index en 2 que es la velocidad

            Critter newCritter = new Critter("Alma", 10, 15, 20, 5, 300); //creamos una nueva criatura para combatir

            Console.WriteLine("Velocidad Base: " + newCritter.BaseSpeed); //mostrams la velocidad base y la momentanea o de combate para hacer comparativa
            Console.WriteLine("Velocidad Momentanea: " + newCritter.CurrentSpd);

            if (dwnSpeed.Name == "SpdDwn")
                newCritter.AlterState(2);
           
            Console.WriteLine("Velocidad Momentanea: " + newCritter.CurrentSpd); //mostramos la velocidad momentanea o de combatre para ver si cambio


        }

        static public void DefenseUpReview()
        {
            SupportSkill newSkill = new SupportSkill("X", 10, 1); //creamos la skill para probar con la subida de armadura 
            Critter newCritter = new Critter("Alma", 10, 15, 20, 5, 300); //creamos una nueva criatura para combatir

            Console.WriteLine("Defensa base: " + newCritter.BaseDefense); // mostramos tanto la defensa base como la de combate para hacer una comparativa
            Console.WriteLine("Defensa de combate: " + newCritter.CurrentDef);
            //ahora reproducimos la skill mas de tres veces
             for (int i = 0; i < 4; i++)
             {
                if (newSkill.Name == "DefUp")
                {
                    newCritter.AlterState(1);
                }
                Console.WriteLine(" intento: {0} Defensa de combate: " + newCritter.CurrentDef, i+1);
            }
           
           

            Console.WriteLine(" Defensa de combate: " + newCritter.CurrentDef); //mostramos la defensa de combate para revisar a partir de la tercera no sube mas

        }
   
        static public void CombatEarthFireReview()
        {
            Affinity affinityTable = new Affinity(); //invocamos la clase de affinidades para acceder a la tabla de tipos

            Critter defCritter = new Critter("Alma", 10, 15, 20, 3, 500); //creamos una nueva criatura para combatir de elemento tierra
            Critter atqCritter = new Critter("Alma", 10, 60, 20, 0, 350); //creamos un criter atacante y uno defensor

            Console.WriteLine("Afinidad del critter: " + defCritter.Affinity); //mostramos que si sea de afinidad tierra

            AttackSkill attackSkill1 = new AttackSkill("pancho Power", 10, 0); //creamos el ataque de daño de fuego
            atqCritter.DefineSkills(3, attackSkill1); //le damos el ataque;
           

            Console.WriteLine("Afinidad del Ataque: " + attackSkill1.MyAffinity); //mostrar para saber si si es de afinidad de fuego

            Console.WriteLine("Vida del Critter: " + defCritter.Hp); //mostramos la vida antes del ataque

            //procedemos al ataque 

            if(attackSkill1 is AttackSkill)
            {
               float mult = affinityTable.AfinityTable(attackSkill1.MyAffinity, defCritter.Affinity); //con la tabla de tipos logramos sacar el multiplicador

                defCritter.OnHit(atqCritter.CurrentAtq, atqCritter.Moveset[0].Power, mult);
            }

            Console.WriteLine("Vida del Critter: " + defCritter.Hp); //mostramos la vida despues del ataque
        }

        static public void CombatWindWaterReview()
        {
            Affinity affinityTable = new Affinity(); //invocamos la clase de affinidades para acceder a la tabla de tipos

            Critter defCritter = new Critter("Alma", 10, 15, 20, 1, 250); //creamos una nueva criatura para combatir de elemento Viento
            Critter atqCritter = new Critter("Nero", 60, 60, 20, 2, 400); //creamos un criter atacante y uno defensor

            Console.WriteLine("Afinidad del critter: " + defCritter.Affinity); //mostramos que si sea de afinidad Viento

            AttackSkill attackSkill1 = new AttackSkill("pancho Power", 10, 2); //creamos el ataque de daño de Agua
            atqCritter.DefineSkills(3, attackSkill1); //le damos el ataque;


            Console.WriteLine("Afinidad del Ataque: " + attackSkill1.MyAffinity); //mostrar para saber si si es de afinidad de Agua

            Console.WriteLine("Vida del Critter: " + defCritter.Hp); //mostramos la vida antes del ataque

            //procedemos al ataque 

            if (attackSkill1 is AttackSkill)
            {
                float mult = affinityTable.AfinityTable(attackSkill1.MyAffinity, defCritter.Affinity); //con la tabla de tipos logramos sacar el multiplicador
                Console.WriteLine(mult);
                defCritter.OnHit(atqCritter.CurrentAtq, atqCritter.Moveset[0].Power, mult);
            }

            Console.WriteLine("Vida del Critter: " + defCritter.Hp); //mostramos la vida despues del ataque
        }

        static public void CombatSimulator()
        {
            Affinity affinity = new Affinity(); //definimos las afinidades para acceder a la tableta
            Player player1 = new Player();
            Player player2 = new Player();


            //Critter defCritter = new Critter("Alma", 75, 15, 50, 2, 500); //creamos una nueva criatura para combatir 
            //Critter atqCritter = new Critter("Alma", 20, 60, 20, 1, 350); //creamos un criter atacante y uno defensor

            //player1.Critters.Add(defCritter); // le agregamos los criter a cada usuario
            //player2.Critters.Add(atqCritter);

            // AttackSkill attackSkillP1 = new AttackSkill("pancho Power", 10, 2); //creamos un ataque momentaneo para el primer critter
            //AttackSkill attackSkillP2 = new AttackSkill("pancho Power", 5, 1); // creamos un ataque momentaneo para el segundo

        

            Random range = new Random();


            //player1.Critters[0].DefineSkills(1, attackSkillP1); //le agregamos los ataques al move set
            //player2.Critters[0].DefineSkills(1, attackSkillP2);

            player1.EquipCritters(1);
            player2.EquipCritters(1);

            int coin = range.Next(0, 2);

            while (player2.Critters[0].Hp >= 0 || player1.Critters[0].Hp >=0)
            {
                if (player2.Critters[0].BaseSpeed > player1.Critters[0].BaseSpeed)
                {
                    if (player2.Critters[0].Moveset[0] is AttackSkill askil)
                    {
                        askil = player2.Critters[0].Moveset[0] as AttackSkill;

                        float mult = affinity.AfinityTable(askil.MyAffinity, player1.Critters[0].Affinity);
                        player1.Critters[0].OnHit(player2.Critters[0].BaseAttack, askil.Power, mult);

                        if (player1.Critters[0].Hp <= 0)
                            break;
                    }
                    if (player1.Critters[0].Moveset[0] is AttackSkill askil1)
                    {
                        askil1 = player1.Critters[0].Moveset[0] as AttackSkill;

                        float mult = affinity.AfinityTable(askil1.MyAffinity, player2.Critters[0].Affinity);
                        player2.Critters[0].OnHit(player1.Critters[0].BaseAttack, askil1.Power, mult);

                        if (player2.Critters[0].Hp <= 0)
                            break;
                    }

                }
                else if (player1.Critters[0].BaseSpeed > player2.Critters[0].BaseSpeed)
                {
                    if (player1.Critters[0].Moveset[0] is AttackSkill askil)
                    {
                        askil = player1.Critters[0].Moveset[0] as AttackSkill;

                        float mult = affinity.AfinityTable(askil.MyAffinity, player2.Critters[0].Affinity);
                        player2.Critters[0].OnHit(player1.Critters[0].BaseAttack, askil.Power, mult);

                        if (player2.Critters[0].Hp <= 0)
                            break;
                    }
                    if (player2.Critters[0].Moveset[0] is AttackSkill askil1)
                    {
                        askil1 = player2.Critters[0].Moveset[0] as AttackSkill;

                        float mult = affinity.AfinityTable(askil1.MyAffinity, player1.Critters[0].Affinity);
                        player1.Critters[0].OnHit(player2.Critters[0].BaseAttack, askil1.Power, mult);

                        if (player1.Critters[0].Hp <= 0)
                            break;

                    }

                }
                else if (player2.Critters[0].BaseSpeed ==  player1.Critters[0].BaseSpeed && coin == 0 )
                {
                    if (player2.Critters[0].Moveset[0] is AttackSkill askil)
                    {
                        askil = player2.Critters[0].Moveset[0] as AttackSkill;

                        float mult = affinity.AfinityTable(askil.MyAffinity, player1.Critters[0].Affinity);
                        player1.Critters[0].OnHit(player2.Critters[0].BaseAttack, askil.Power, mult);

                        if (player1.Critters[0].Hp <= 0)
                            break;
                    }
                    if (player1.Critters[0].Moveset[0] is AttackSkill askil1)
                    {
                        askil1 = player1.Critters[0].Moveset[0] as AttackSkill;

                        float mult = affinity.AfinityTable(askil1.MyAffinity, player2.Critters[0].Affinity);
                        player2.Critters[0].OnHit(player1.Critters[0].BaseAttack, askil1.Power, mult);

                        if (player2.Critters[0].Hp <= 0)
                            break;
                    }

                }
               else if (player1.Critters[0].BaseSpeed == player2.Critters[0].BaseSpeed && coin == 1)
                {
                    if (player1.Critters[0].Moveset[0] is AttackSkill askil)
                    {
                        askil = player1.Critters[0].Moveset[0] as AttackSkill;

                        float mult = affinity.AfinityTable(askil.MyAffinity, player2.Critters[0].Affinity);
                        player2.Critters[0].OnHit(player1.Critters[0].BaseAttack, askil.Power, mult);

                        if (player2.Critters[0].Hp <= 0)
                            break;
                    }
                    if (player2.Critters[0].Moveset[0] is AttackSkill askil1)
                    {
                        askil1 = player2.Critters[0].Moveset[0] as AttackSkill;

                        float mult = affinity.AfinityTable(askil1.MyAffinity, player1.Critters[0].Affinity);
                        player1.Critters[0].OnHit(player2.Critters[0].BaseAttack, askil1.Power, mult);

                        if (player1.Critters[0].Hp <= 0)
                            break;
                    }

                }
            }

            Console.WriteLine("-----------------------------------------------------------------");

            if (player2.Critters[0].Hp <= 0)
            {
                Console.WriteLine("Cantidad de Criaturas Player 1: " + player1.Critters.Count);
                Console.WriteLine("Cantidad de Criaturas Player 2: " + player2.Critters.Count);
                Console.WriteLine("-----------------------------------------------------------------");

                player1.Critters.Add(player2.Critters[0]);
                player2.Critters.Remove(player2.Critters[0]);


                Console.WriteLine("Cantidad de Criaturas Player 1: " + player1.Critters.Count);
                Console.WriteLine("Cantidad de Criaturas Player 2: " + player2.Critters.Count);
                Console.WriteLine("Ganador:  Player 1 ");
            }
           
            Console.WriteLine("-----------------------------------------------------------------");
           
            if (player1.Critters[0].Hp <= 0)
            {
                Console.WriteLine("Cantidad de Criaturas Player 1: " + player1.Critters.Count);
                Console.WriteLine("Cantidad de Criaturas Player 2: " + player2.Critters.Count);
                Console.WriteLine("-----------------------------------------------------------------");

                player2.Critters.Add(player1.Critters[0]);
                player1.Critters.Remove(player1.Critters[0]);

                Console.WriteLine("Cantidad de Criaturas Player 1: " +  player1.Critters.Count);
                Console.WriteLine("Cantidad de Criaturas Player 2: " + player2.Critters.Count);

                Console.WriteLine("Ganador:  Player 2 ");
            }

        }
    }
}
