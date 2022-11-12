using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkOS
{
    public class Cluster
    {
        public byte[] bytes { get; set; }

        public Cluster(byte[] bytes,int cluster_size)
        {
            this.bytes = bytes;
        }

        public Cluster(int cluster_size)
        {
            this.bytes = new byte[cluster_size];
        }

        //Запись кластера в бинарный файл
        public bool binaryWritingToFile(BinaryWriter bw)
        {
            try
            {
                bw.Write(this.bytes);
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
                return false;
            }
        }

        //Загрузка информации о кластере из файла
        public static Cluster loadClusterFromBinaryFile(BinaryReader reader,int cluster_size)
        {
            Cluster cluster = new Cluster(cluster_size);

            try
            {
                byte[] data = reader.ReadBytes(cluster_size);

                cluster.bytes = data;

                //cluster.bytes = Converter.convertFromBytesIntoChar(data);
            }
            catch (Exception e)
            {
                Console.Write("Exception happened:\n" + e);
            }
            return cluster;
        }
        
    }
}
