// Autores: Lucas Ferreira, Joao Garcia, Susana Domingues
// Codigos: a22409970, a22407084, a22409880
// Data: 21/03/2025

using System;

namespace Estrutura_Array
{
    class Program
    {

        struct Colaborator
        {
            public int colab_cod;
            public string colab_name;
            public byte colab_age;
            public double colab_salary;
        }

        // function to check if the written value is an integer
        static bool VerifyIsInt(ref int number)
        {
            if (int.TryParse(Console.ReadLine(), out number))
                return true;
            else
                return false;
        }

        // Check if the employee code is registered
        static bool VerifyCode(Colaborator[] scolab, int code)
        {
            foreach (var colab in scolab)
            {
                if (colab.colab_cod == code) // Verifica se o código já foi criado
                {
                    Console.WriteLine("Já existe um colaborador com este código. Por favor tente outro código."); // Mensagem de erro
                    return true; // Retorna verdadeiro indicando que o código já existe
                }
            }
            return false; // Retorna falso caso o código não exista
        }

        // Function insert colaborator
        static void InsertColaborator(ref Colaborator[] collaborator)
        {
            Array.Resize(ref collaborator, collaborator.Length + 1);

            int index = collaborator.Length - 1;
            int cod_collab = 0;

            Console.WriteLine("Enter the collaborator's details:");

            
            Console.Write("Collaborator Code: ");
            cod_collab = int.Parse(Console.ReadLine());

            // Verify if cod colaborator exist
            if (!VerifyCode(collaborator, cod_collab))
            {
                // Insert collaborator code
                collaborator[index].colab_cod = cod_collab;

                // Insert collaborator name
                Console.Write("Collaborator Name: ");
                collaborator[index].colab_name = Console.ReadLine();

                // Insert collab_age
                Console.Write("Collaborator Age: ");
                collaborator[index].colab_age = byte.Parse(Console.ReadLine());

                // Insert collab_salary
                Console.Write("Collaborator Salary: ");
                collaborator[index].colab_salary = double.Parse(Console.ReadLine());
            }
        }

        // Function update colaborator
        static void UpdateColaborator(ref Colaborator[] collaborator, int index)
        {

            if (index >= 0 && index < collaborator.Length)
            {
                // Insert collaborator code
                Console.Write("Collaborator Code: ");
                collaborator[index].colab_cod = int.Parse(Console.ReadLine());

                // Insert collaborator name
                Console.Write("Collaborator Name: ");
                collaborator[index].colab_name = Console.ReadLine();

                // Insert collab_age
                Console.Write("Collaborator Age: ");
                collaborator[index].colab_age = byte.Parse(Console.ReadLine());

                // Insert collab_salary
                Console.Write("Collaborator Salary: ");
                collaborator[index].colab_salary = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Position not available");
            }
        }

        // Função para eliminar os colaboradores
        static void RemoveColab(ref Colaborator[] scolab)
        {
            Console.Write("Código do colaborador que deseja eliminar: ");
            int codigo;
            if (!int.TryParse(Console.ReadLine(), out codigo))
            {
                Console.WriteLine("Código inválido.");
                return;
            }

            int index = -1;
            for (int i = 0; i < scolab.Length; i++)
            {
                if (scolab[i].colab_cod == codigo)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Console.WriteLine("Colaborador não encontrado.");
                return;
            }

            Colaborator[] newArray = new Colaborator[scolab.Length - 1];
            for (int i = 0, j = 0; i < scolab.Length; i++)
            {
                if (i != index)
                {
                    newArray[j++] = scolab[i];
                }
            }
            scolab = newArray;

            Console.WriteLine("Colaborador eliminado com sucesso.");
        }

        // Função para consultar os colaboradores
        static void ConsultColab(Colaborator[] scolab)
        {
            Console.Write("Digite o código do colaborador para consulta: ");
            int codigo;
            if (!int.TryParse(Console.ReadLine(), out codigo))
            {
                Console.WriteLine("Código inválido.");
                return;
            }

            foreach (var colab in scolab)
            {
                if (colab.colab_cod == codigo)
                {
                    Console.WriteLine($"Código: {colab.colab_cod}");
                    Console.WriteLine($"Nome: {colab.colab_name}");
                    Console.WriteLine($"Idade: {colab.colab_age}");
                    Console.WriteLine($"Vencimento: {colab.colab_salary}");
                    return;
                }
            }
            Console.WriteLine("Colaborador não encontrado.");
        }

        // Function to list all collaborators
        static void ListColab(Colaborator[] scolab)
        {
            foreach (var colab in scolab)
            {
                Console.WriteLine($"Código: {colab.colab_cod}");
                Console.WriteLine($"Nome: {colab.colab_name}");
                Console.WriteLine($"Idade: {colab.colab_age}");
                Console.WriteLine($"Vencimento: {colab.colab_salary}");
                Console.WriteLine("-------------------------");
            }
        }

        // Function to list collaborator
        static void ShowNumberColab(Colaborator[] scolab)
        {
            Console.WriteLine($"The program has {scolab.Length} users!");
        }



        // menu function
        static void ShowMenu()
        {
            Console.WriteLine("1. Insert collaborators");
            Console.WriteLine("2. Consult collaborator");
            Console.WriteLine("3. List all collaborators");
            Console.WriteLine("4. Change collaborator");
            Console.WriteLine("5. Delete collaborator");
            Console.WriteLine("6. Show number of associated collaborators");
            Console.WriteLine("0. Exit");

            Console.Write("choose an option: ");
        }

        static void Main(string[] args)
        {
            // Create all necessary variables
            int chosen_menu = 0;
            int number_chosen = 0;

            bool flag_chosen;


            Console.WriteLine("Welcome to employee program");

            // Init struct
            Colaborator[] struct_colab = new Colaborator[0];

            do
            {
                // Call func Menu
                ShowMenu();

                // Verify if number chosen is int
                flag_chosen = VerifyIsInt(ref chosen_menu);

                if (!flag_chosen)
                {
                    Console.WriteLine("Invalid value entered!");
                    continue;
                }

                // Processes menu selection
                switch (chosen_menu)
                {
                    case 1:
                        Console.WriteLine("Insert collaborators!");

                        Console.WriteLine("How many colaborators do you want to insert?");
                        flag_chosen = VerifyIsInt(ref number_chosen);

                        if (!flag_chosen)
                        {
                            Console.WriteLine("Invalid value entered!");
                            break;
                        }

                        for (int index = 0; index < number_chosen; index++)
                        {
                            InsertColaborator(ref struct_colab);
                        }

                        Console.WriteLine("Data entered successfully!");
                        break;

                    case 2:
                        Console.WriteLine("Cnsult collaborator!");
                        ConsultColab(struct_colab);
                        break;

                    case 3:
                        Console.WriteLine("List collaborators!");
                        ListColab(struct_colab);
                        break;

                    case 4:
                        Console.WriteLine("Update collaborator!");

                        Console.WriteLine("What is the employee code?");
                        flag_chosen = VerifyIsInt(ref number_chosen);

                        if (!flag_chosen)
                        {
                            Console.WriteLine("Invalid value entered!");
                            break;
                        }

                        UpdateColaborator(ref struct_colab, number_chosen);

                        Console.WriteLine("Data updated successfully!");
                        break;

                    case 5:
                        Console.WriteLine("Delete collaborator!");
                        RemoveColab(ref struct_colab);
                        break;

                    case 6:
                        Console.WriteLine("List number collaborators!");
                        ShowNumberColab(struct_colab);
                        break;

                    case 0:
                        Console.WriteLine("Leaving the program, goodbye.");
                        break;

                    default:
                        Console.WriteLine("Value not assigned, please choose a number from the list!");
                        break;
                }


            } while (flag_chosen == false || chosen_menu != 0);





        }
    }
}


/*
 Funcionalidades:

Lucas Ferreira: 1. 4. 6.
Joao vitor: 2. 5. 
Susana Domingues: 3.

1. Inserir "n" colabs # Nota: Verificar se ja existe pelo cod #
2. Consultar o colab (pelo cod do colaborador) # Nota: Verificar se ja existe esse colaborador pelo cod #
3. Listar Colabs 
4. Alterar colab
5. Eleminar colab
6. Numero total de colabs
0. Sair do programa

Nao fazer agora como trabalho:

7. Media de idades
8. Maior vencimento
9. Menor vencimento
10. Download de estroturas para ficheiro
11. Upload de estroturas para array

 */

/*
struct_Colab[0].iCodColab = 1;
struct_Colab[0].stNomeColab = "Diogo";

struct_Colab[1].iCodColab = 2;
struct_Colab[1].stNomeColab = "Rui";

Console.WriteLine("Dados de saida: \n\n");

for (int index = 0; index < struct_Colab.Length; index++)
{
    Console.WriteLine($" Cod colaborador: {struct_Colab[index].iCodColab} \n Nome coloborador: {struct_Colab[index].stNomeColab} \n\n");
}
 */