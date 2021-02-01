using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("if you do not have any key, enter '0'");
            Console.WriteLine("if you have 'pro' key, enter '1'");
            Console.WriteLine("if you have 'exp' key, enter '2'");
            var ok = Int32.TryParse(Console.ReadLine(), out var input);
            if (!ok) {
                Console.WriteLine("bad input");
                return;
            }

            var docWorker = input switch
            {
                0 => new DocumentWorker(),
                1 => new ProDocumentWorker(),
                2 => new ExpertDocumentWorker(),
                _ => throw new ArgumentException()
            };

            docWorker.OpenDocument();
            docWorker.EditDocument();
            docWorker.SaveDocument();

            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine();

            IPlayable iplay = new Player();
            IRecodable irecord = new Player();
            iplay.Play();
            irecord.Record();
            iplay.Pause();
            iplay.Stop();
        }
    }

    class DocumentWorker
    {
        public void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }
        virtual public void EditDocument()
        {
            Console.WriteLine("Редактирование документа доступно в версии Про");
        }
        virtual public void SaveDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии Про");
        }
    }

    class ProDocumentWorker : DocumentWorker
    {
        override public void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }
        override public void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
        }
    }

    class ExpertDocumentWorker : ProDocumentWorker
    {
        override public void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
    }

    interface IPlayable
    {
        void Play();
        void Pause();
        void Stop();
    }

    interface IRecodable
    {
        void Record();
        void Pause();
        void Stop();
    }

    class Player : IPlayable, IRecodable
    {
        public void Play()
        {
            Console.WriteLine("Play");
        }

        public void Record()
        {
            Console.WriteLine("Record");
        }
        public void Pause()
        {
            Console.WriteLine("Pause");
        }
        public void Stop()
        {
            Console.WriteLine("Stop");
        }
    }
    
}
