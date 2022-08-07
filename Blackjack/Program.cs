using System;

namespace BlackJack
{
    public class Program
    {

        public static bool rest = true;

        static void Main(string[] args)
        {

            Crupier crupier = new Crupier();

            Jugador JUno = new Jugador(crupier.darCarta(), crupier.darCarta());
            Jugador JDos = new Jugador(crupier.darCarta(), crupier.darCarta());

            while (rest)
            {
                Console.Clear();
                int MesaDeApuesta = 0;
                JUno.gano(0);
                JDos.gano(0);

                JUno.otraMano(crupier.darCarta(), crupier.darCarta());
                JDos.otraMano(crupier.darCarta(), crupier.darCarta());

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("----------Bienvenido-a-BLACK-JACK------------");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("-1.-Jugar-contra-la-mesa---------------------");
                Console.WriteLine("-2.-Jugar-jugador-contra-jugador-vs-Mesa-----");
                Console.WriteLine("-3.-Reglas-----------------------------------");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("-4.-Salir------------------------------------");
                Console.WriteLine("---------------------------------------------");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        Console.Clear();
                        MesaDeApuesta += JUno.apostar();
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine(" El Jugador 1 " + JUno.mostrarMano());
                        Console.WriteLine("---------------------------------------------");
                        crupier.mostrarMano();
                        Console.WriteLine("---------------------------------------------");



                        if (pedirPlantarse())
                        {
                            JUno.pedir(crupier.darCarta());
                        } 

                        if(JUno.mostrarManoFinal() >= crupier.mostrarManoFinal() && JUno.mostrarManoFinal() <= 21)
                        {
                            JUno.gano(MesaDeApuesta * 2);
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("-----------FELICIDADES-GANASTE!!!------------");
                            Console.WriteLine("-La-mano-del-jugador-es-" + JUno.mostrarManoFinal() +"-Y-el-de-la-mesa-es-"+ crupier.mostrarManoFinal() +"----");
                            JUno.ganancia();
                        }
                        else 
                        {
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("-----------QUE-LASTIMA-PERDISTE-:(-----------");
                            Console.WriteLine("-La-mano-del-jugador-es-" + JUno.mostrarManoFinal() + "-Y-el-de-la-mesa-es-" + crupier.mostrarManoFinal() + "----");
                            Console.WriteLine("---------------------------------------------");
                        }

                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("---JuadorUno:--------------------------------");
                        MesaDeApuesta += JUno.apostar();
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("---JuadorDos:--------------------------------");
                        MesaDeApuesta += JDos.apostar();
                        Console.Clear();

                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine(" El Jugador 1 " + JUno.mostrarMano());
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine(" El Jugador 2 " + JDos.mostrarMano());
                        Console.WriteLine("---------------------------------------------");
                        crupier.mostrarMano();
                        Console.WriteLine("---------------------------------------------");

                        Console.WriteLine("---JuadorUno:--------------------------------");
                        Console.WriteLine("---------------------------------------------");
                        if (pedirPlantarse())
                        {
                            JUno.pedir(crupier.darCarta());
                        }

                        Console.WriteLine("---JuadorDos:--------------------------------");
                        Console.WriteLine("---------------------------------------------");
                        if (pedirPlantarse())
                        {
                            JDos.pedir(crupier.darCarta());
                        }

                        if (nosePaso(JUno.mostrarManoFinal()))
                        {
                            if (nosePaso(JDos.mostrarManoFinal()) == false)
                            {
                                if(JUno.mostrarManoFinal() >= crupier.mostrarManoFinal())
                                {
                                    JUno.gano(MesaDeApuesta);
                                    Console.WriteLine("---------------------------------------------");
                                    Console.WriteLine("-----FELICIDADES-JUGADOR-1-GANASTE!!!--------");
                                    Console.WriteLine("-La-mano-del-jugador-1-es-" + JUno.mostrarManoFinal() + "-Y-el-de-la-mesa-es-" + crupier.mostrarManoFinal() + "----");
                                    Console.WriteLine("-La-mano-del-jugador-2-es-" + JDos.mostrarManoFinal());
                                    JUno.ganancia();
                                }
                                else
                                {
                                    Console.WriteLine("---------------------------------------------");
                                    Console.WriteLine("----------QUE-LASTIMA-PERDIERON-:(-----------");
                                    Console.WriteLine("-La-mano-del-jugador-1-es-" + JUno.mostrarManoFinal() + "-Y-el-de-la-mesa-es-" + crupier.mostrarManoFinal() + "----");
                                    Console.WriteLine("-La-mano-del-jugador-2-es-" + JDos.mostrarManoFinal());
                                    Console.WriteLine("---------------------------------------------");
                                }
                            }
                            else
                            {
                                if(JUno.mostrarManoFinal() > JDos.mostrarManoFinal())
                                {
                                    if (JUno.mostrarManoFinal() >= crupier.mostrarManoFinal())
                                    {
                                        JUno.gano(MesaDeApuesta);
                                        Console.WriteLine("---------------------------------------------");
                                        Console.WriteLine("-----FELICIDADES-JUGADOR-1-GANASTE!!!--------");
                                        Console.WriteLine("-La-mano-del-jugador-1-es-" + JUno.mostrarManoFinal() + "-Y-el-de-la-mesa-es-" + crupier.mostrarManoFinal() + "----");
                                        Console.WriteLine("-La-mano-del-jugador-2-es-" + JDos.mostrarManoFinal());
                                        JUno.ganancia();
                                    }
                                    else
                                    {
                                        Console.WriteLine("---------------------------------------------");
                                        Console.WriteLine("----------QUE-LASTIMA-PERDIERON-:(-----------");
                                        Console.WriteLine("-La-mano-del-jugador-1-es-" + JUno.mostrarManoFinal() + "-Y-el-de-la-mesa-es-" + crupier.mostrarManoFinal() + "----");
                                        Console.WriteLine("-La-mano-del-jugador-2-es-" + JDos.mostrarManoFinal());
                                        Console.WriteLine("---------------------------------------------");
                                    }
                                }
                                else if(JUno.mostrarManoFinal() == JDos.mostrarManoFinal())
                                {
                                    Console.WriteLine("---------------------------------------------");
                                    Console.WriteLine("----------NO-HAY-GANADORES-:(----------------");
                                    Console.WriteLine("-La-mano-del-jugador-1-es-" + JUno.mostrarManoFinal());
                                    Console.WriteLine("-La-mano-del-jugador-2-es-" + JDos.mostrarManoFinal());
                                    Console.WriteLine("---------------------------------------------");
                                }
                                else
                                {
                                    if (JDos.mostrarManoFinal() >= crupier.mostrarManoFinal())
                                    {
                                        JDos.gano(MesaDeApuesta);
                                        Console.WriteLine("---------------------------------------------");
                                        Console.WriteLine("-----FELICIDADES-JUGADOR-2-GANASTE!!!--------");
                                        Console.WriteLine("-La-mano-del-jugador-2-es-" + JDos.mostrarManoFinal() + "-Y-el-de-la-mesa-es-" + crupier.mostrarManoFinal() + "----");
                                        Console.WriteLine("-La-mano-del-jugador-1-es-" + JUno.mostrarManoFinal());
                                        JDos.ganancia();
                                    }
                                    else
                                    {
                                    Console.WriteLine("---------------------------------------------");
                                    Console.WriteLine("----------QUE-LASTIMA-PERDIERON-:(-----------");
                                    Console.WriteLine("-La-mano-del-jugador-1-es-" + JUno.mostrarManoFinal() + "-Y-el-de-la-mesa-es-" + crupier.mostrarManoFinal() + "----");
                                    Console.WriteLine("-La-mano-del-jugador-2-es-" + JDos.mostrarManoFinal());
                                    Console.WriteLine("---------------------------------------------");
                                    }
                                }
                            }
                        }
                        else if (nosePaso(JDos.mostrarManoFinal()))
                        {
                            if (JDos.mostrarManoFinal() >= crupier.mostrarManoFinal())
                            {
                                JDos.gano(MesaDeApuesta);
                                Console.WriteLine("---------------------------------------------");
                                Console.WriteLine("-----FELICIDADES-JUGADOR-2-GANASTE!!!--------");
                                Console.WriteLine("-La-mano-del-jugador-2-es-" + JDos.mostrarManoFinal() + "-Y-el-de-la-mesa-es-" + crupier.mostrarManoFinal() + "----");
                                Console.WriteLine("-La-mano-del-jugador-1-es-" + JUno.mostrarManoFinal());
                                JDos.ganancia();
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------------");
                                Console.WriteLine("----------QUE-LASTIMA-PERDIERON-:(-----------");
                                Console.WriteLine("-La-mano-del-jugador-1-es-" + JUno.mostrarManoFinal() + "-Y-el-de-la-mesa-es-" + crupier.mostrarManoFinal() + "----");
                                Console.WriteLine("-La-mano-del-jugador-2-es-" + JDos.mostrarManoFinal());
                                Console.WriteLine("---------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("----------QUE-LASTIMA-PERDIERON-:(-----------");
                            Console.WriteLine("-La-mano-del-jugador-1-es-" + JUno.mostrarManoFinal() + "-Y-el-de-la-mesa-es-" + crupier.mostrarManoFinal() + "----");
                            Console.WriteLine("-La-mano-del-jugador-2-es-" + JDos.mostrarManoFinal());
                            Console.WriteLine("---------------------------------------------");
                        }
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("------------------*REGLAS*-------------------");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("--*Solo-puedes-ganar-cuando:-----------------");
                        Console.WriteLine("---.Tu-mano-es-menor-o-igual-que-21-y-sea----");
                        Console.WriteLine("----siempre-mayor-que-la-mano-de-tus---------");
                        Console.WriteLine("----contrincantes-y-de-la-mesa---------------");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("--------------*COMO-SE-JUEGA*----------------");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("-1.Debes-apostar-para-ingresar---------------");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("-2.La-mesa-reparte-2-cartas-por-jugador-y-2--");
                        Console.WriteLine("---para-la-mesa(solo-se-vera-el-valor-de-una)");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("-3.Dependiendo-el-valor-de-tu-mano-vas-a-----");
                        Console.WriteLine("---pedir-o-pasar-una-carta-------------------");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("-4.Se-determina-el-ganador-de-la-partida-----");
                        Console.WriteLine("---correspondinte-a-las-reglas---------------");
                        Console.WriteLine("---------------------------------------------");

                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        salir();
                        break;
                    default:
                        valorIncorrecto();
                        break;
                }
            }
        }

        private static bool nosePaso(int v)
        {
            if(v <= 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool pedirPlantarse()
        {
            Console.WriteLine("-Deseas-pedir-o-te-plantas?------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("-1-Pedir-------------------------------------");
            Console.WriteLine("-2-Plantarse---------------------------------");
            Console.WriteLine("---------------------------------------------");
            string op = Console.ReadLine();

            if (op == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void valorIncorrecto()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--------------Valor-Incorrecto---------------");
        }

        private static void salir()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------Seguro-que-quieres-salir?-----------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("-1.-Si---------------------------------------");
            Console.WriteLine("-2.-No---------------------------------------");
            Console.WriteLine("---------------------------------------------");
            string op = Console.ReadLine();

            if (op == "1")
            {
                rest = false;
                
            }
            else if (op == "2")
            {
                rest = true;
                Console.Clear();
            }
            else
            {
                valorIncorrecto();
                salir();
            }
        }
    }

    class Jugador
    {
        protected char[] carts = new char[3];
        protected int ganacia;

        public Jugador(char cartOne, char cartTwo)
        {
            this.carts[0] = cartOne;
            this.carts[1] = cartTwo;
            this.carts[2] = '0';
        }
        public void ganancia()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("-Ganaste-$"+ganacia+"------------------------");
            Console.WriteLine("---------------------------------------------");

        }
        public int apostar() 
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("-Cuanto-desea-apostar:-----------------------");
            try { 
                int dinero = int.Parse(Console.ReadLine());
                return dinero;
            }
            catch(Exception e)
            {
                return 0;
            }
            
        }

        public void gano(int suma)
        {
            ganacia = suma;
        }

        public void pedir(char nuevaCarta)
        {
            carts[2] = nuevaCarta;
        }

        public string mostrarMano()
        {
            char cartOne = carts[0],
                   cartTwo = carts[1];
            int one = TipoDeCarta(cartOne),
                two = TipoDeCarta(cartTwo);

            return ("recibe "+cartOne+", "+cartTwo+" = "+(one+two));

        }

        public int mostrarManoFinal()
        {
            char cartOne = carts[0], 
                   cartTwo = carts[1], 
                   cartThree = carts[2];
            int one = TipoDeCarta(cartOne),
                two = TipoDeCarta(cartTwo),
                three = TipoDeCarta(cartThree);

            if (carts[2] != '0')
            {
                return one + two + three;
            }
            else
            {
                return one + two;
            }
        }

        protected int TipoDeCarta(char cart)
        {
            switch (cart)
            {
                case 'A':
                    return 1;
                case 'X':
                case 'J':
                case 'Q':
                case 'K':
                    return 10;
                default:
                    return int.Parse(cart.ToString());
            }
        }

        internal void otraMano(char v1, char v2)
        {
            this.carts[0] = v1;
            this.carts[1] = v2;
        }
    }

    class Crupier
    {
        protected int ganaciaMesa;

        protected char[] cartsMesa = new char[2];

        protected char[] mazo = new char[13] { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'X', 'J', 'Q', 'K'};

        Random cartsAleatori = new Random();

        public Crupier()
        {
            this.cartsMesa[0] = mazo[cartsAleatori.Next(0, 12)];
            this.cartsMesa[1] = mazo[cartsAleatori.Next(0, 12)];
        }

        public void gano(int suma)
        {
            ganaciaMesa += suma;
        }


        internal char darCarta()
        {
            return mazo[cartsAleatori.Next(0, 12)];
        }

        public int mostrarManoFinal()
        {
            char cartOne = cartsMesa[0],
                   cartTwo = cartsMesa[1];

            int one = TipoDeCarta(cartOne),
                two = TipoDeCarta(cartTwo);

            return one + two;
        }

        public void mostrarMano()
        {
            Console.WriteLine("Primera carta de la mesa: " + cartsMesa[0] + ", Segunda carta: SECRETO");
        }

        protected int TipoDeCarta(char cart)
        {
            switch (cart)
            {
                case 'A':
                    return 1;
                case 'X':
                case 'J':
                case 'Q':
                case 'K':
                    return 10;
                default:
                    return int.Parse(cart.ToString());
            }
        }
    }
}