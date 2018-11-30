namespace PetClinic.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class Clinic : IClinic
    {
        private int currentIndex;
        private int capacity;
        private int startingRoom => this.Capacity / 2;
        private int emptyRooms;

        public IPet[] Pets { get; private set; }

        public string Name { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }

                this.capacity = value;
            }
        }        

        public Clinic(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Pets = new IPet[this.Capacity];
            this.emptyRooms = this.Capacity;
            this.currentIndex = 0;
        }

        public bool Add(IPet pet)
        {
            if ((emptyRooms > 0) == false)
            {
                return false;
            }

            var index = GiveNextEmptyRoom();
            this.Pets[index] = pet;

            return true;
        }

        public bool Release()
        {
            bool isReleased = MakeEmptyRoom(this.Pets, this.startingRoom, this.Capacity);

            if (isReleased)
            {
                return true;
            }
            return MakeEmptyRoom(this.Pets, 0, startingRoom);
        }

        public bool HasEmptyRooms() => this.emptyRooms > 0;

        public string Print(int room)
        {
            return $"{this.Pets[room - 1].ToString()}";
        }

        public string Print()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.Pets.Length; i++)
            {
                if (this.Pets[i] != null)
                {
                    sb.AppendLine(this.Pets[i].ToString());                    
                }
                else
                {
                    sb.AppendLine("Room empty");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public IEnumerator<IPet> GetEnumerator()
        {
            foreach (var pet in this.Pets)
            {
                yield return pet;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private int GiveNextEmptyRoom()
        {
            var index = emptyRooms % 2 != 0 ?
              startingRoom + currentIndex++ : startingRoom - currentIndex;

            this.emptyRooms--;
            return index;
        }

        private bool MakeEmptyRoom(IPet[] roomsWithPets, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (roomsWithPets[i] != null)
                {
                    roomsWithPets[i] = null;
                    this.emptyRooms++;
                    return true;
                }
            }
            return false;
        }
    }
}
