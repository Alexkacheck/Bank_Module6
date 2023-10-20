using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Module6
{
    class Program
    {
        static void Main(string[] args)
        {

            int attempts = 0;
            string correctPassword = "2002";
            double balance = 54503.0; // Начальный баланс счета

            while (attempts < 3)
            {
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();

                if (password == correctPassword)
                {
                    Console.WriteLine("Пароль верный. Входи.");

                    while (true)
                    {
                        Console.WriteLine("Меню:");
                        Console.WriteLine("a. Вывод баланса ");
                        Console.WriteLine("b. Пополнение счета");
                        Console.WriteLine("c. Снять деньги со счета");
                        Console.WriteLine("d. Выход");
                        Console.Write("Выберите действие: ");

                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "a":
                                Console.WriteLine($"Баланс: {balance:C}");
                                break;
                            case "b":
                                Console.Write("Введите сумму для пополнения: ");
                                if (double.TryParse(Console.ReadLine(), out double depositAmount))
                                {
                                    balance += depositAmount;
                                    Console.WriteLine($"Счет пополнен. Новый баланс: {balance:C}");
                                }
                                else
                                {
                                    Console.WriteLine("Некорректная сумма.");
                                }
                                break;
                            case "c":
                                Console.Write("Введите сумму для снятия: ");
                                if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                                {
                                    if (withdrawAmount <= balance)
                                    {
                                        balance -= withdrawAmount;
                                        Console.WriteLine($"Сумма снята. Новый баланс: {balance:C}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Недостаточно средств на счете.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректная сумма.");
                                }
                                break;
                            case "d":
                                Console.WriteLine("Выход из программы.");
                                return;
                            default:
                                Console.WriteLine("Неверный выбор. Пожалуйста, выберите опцию из меню.");
                                break;
                        }
                    }
                }
                else
                {
                    attempts++;
                    Console.WriteLine($"Неправильный пароль. Попытка {attempts} из 3");
                }
            }

            Console.WriteLine("Превышено количество попыток. Программа завершена.");
        }
    }
    }

