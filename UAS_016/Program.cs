using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_016
{
    class Node
    {
        public int idObat;
        public int hargaObat;
        public int dosisObat;
        public string nameObat;
        public Node next;
        public Node prev;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNode()
        {
            int idobat;
            int hargaobat;
            int dosisobat;
            string nameobat;
            Console.Write("\nMasukkan ID Obat : ");
            idobat = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Harga Obat : ");
            hargaobat = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Dosis Obat : ");
            dosisobat = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Obat : ");
            nameobat = Console.ReadLine();
            Node newNode = new Node();
            newNode.idObat = idobat;
            newNode.hargaObat = hargaobat;
            newNode.dosisObat = dosisobat;
            newNode.nameObat = nameobat;

            if (START == null || idobat < START.idObat)
            {
                if ((START != null) && (idobat == START.idObat))
                {
                    Console.WriteLine("\nnomor yang sama tidak diijinkan");
                    return;
                }
                newNode.next = START;
                START = newNode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;
            while ((current != null) && (idobat >= current.idObat))
            {
                if (idobat == current.idObat)
                {
                    Console.WriteLine("\nNomor yang sama tidak diijinkan\n");
                    return;
                }
                previous = current;
                current = current.next;
            }

            newNode.next = current;
            previous.next = newNode;
        }
        public bool search(int idobat, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null && idobat != current.idObat; previous = current, current = current.next) { }
            return (current != null);
        }
        public bool dellNode(int idObat)
        {
            Node previous, current;
            previous = current = null;
            if (search(idObat, ref previous, ref current) == false)
                return false;
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nList data siswa : ");
                Console.Write("ID Obat" + "   " + "Dosis Obat" + "    " + "Harga Obat" + "   " + "Nama Obat" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.idObat + "    " + currentNode.dosisObat + "    " + currentNode.hargaObat + "         " + currentNode.nameObat + "\n");
                }
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambahkan data kedalam list");
                    Console.WriteLine("2. Menghapus data dari dalam list");
                    Console.WriteLine("3. Melihat semua data didalam list");
                    Console.WriteLine("4. Mencari data didalam list");
                    Console.WriteLine("5. Exit");
                    Console.Write("\nMasukkan pilihan Anda (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Console.Write("Masukkan id obat yang akan dihapus : ");
                                int idobat = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(idobat) == false)
                                    Console.WriteLine("id tidak ditemukan.");
                                else
                                    Console.WriteLine(" id tersebut " + idobat + " dihapus ");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break ;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("nList Kosong !");
                                    break ;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan id obat yang di cari : ");
                                int idobat = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(idobat, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                {
                                    Console.WriteLine("\nData ketemu");
                                    Console.WriteLine("\nId Obat: " + current.idObat);
                                    Console.WriteLine("\nHarga Obat: " + current.hargaObat);
                                    Console.WriteLine("\nDosis Obat: " + current.dosisObat);
                                    Console.WriteLine("\nNama Obat: " + current.nameObat);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan tidak valid");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck ID yang anda masukkan");
                }
            }
        }
    }
}


//2. SinglyLingkedList. karena algoritma tersebut dapat menampilkan data, mencari data, dan mengurutkan data
//3. array perulangan, linked list mengurutkan data, apabila memerlukan data yang akan dicari dan diurutkan maka gunakan linked, apabila perulangan maka menggunakan array
//4. front, rear
//5. (a) 16,   (b) inorder data berada di posisi kiri kemudian menampilkan akarnya dan yang terkahir menampilkan data yang ada di posisi kanan
