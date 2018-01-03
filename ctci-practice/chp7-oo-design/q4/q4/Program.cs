// This is the parking lot that we see in the Fast and the Furious Tokyo Drift
// Drive a car into a lift and it will automatically move your car to a slot that is available.

using System.Collections.Generic;

namespace q4
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot.Initialize();
            var truck = new Truck();
            var ticket = ParkingLot.Park(truck);
            var payment = 10M;
            var change = ParkingLot.FreeBay(ticket, payment);
            // Dump change out of machine cash slot.
        }

        public static class ParkingLot
        {
            private static int _smallBayLimit;
            private static int _mediumBayLimit;
            private static int _largeBayLimit;
            private static Stack<Bay> _smallBays;
            private static Stack<Bay> _mediumBays;
            private static Stack<Bay> _largeBays;
            private static Dictionary<int, Bay> _usedBays;

            public static void Initialize()
            {
                // Get from config or somewhere else.
                _smallBayLimit =  30;
                _mediumBayLimit =  120;
                _largeBayLimit =  5;

                _usedBays = new Dictionary<int, Bay>();

                _smallBays = new Stack<Bay>(new List<Bay>
                {
                    new Bay
                    {
                        Id = 1,     // 2, 3, 4... all bays have unique Ids (even among the sizes)
                        Level = 1,
                        VehicleType = VehicleType.Motorcycle
                    }
                });

                _mediumBays = new Stack<Bay>(new List<Bay>
                {
                    new Bay
                    {
                        Id = 31,     // .etc
                        Level = 1,
                        VehicleType = VehicleType.Car
                    }
                });

                _largeBays = new Stack<Bay>(new List<Bay>
                {
                    new Bay
                    {
                        Id = 151,     // .etc
                        Level = 1,
                        VehicleType = VehicleType.Truck
                    }
                });
            }

            public static TicketMachine TicketMachine { get; } = new TicketMachine();

            // For signboard display
            public static int SmallBaysAvailableCount => _smallBays.Count;
            public static int MediumBaysAvailableCount => _mediumBays.Count;
            public static int LargeBaysAvailableCount => _largeBays.Count;

            public static Ticket Park(IVehicle vehicle)
            {
                var ticket = TicketMachine.PrintTicket();
                var type = GetType(vehicle);
                AddToBay(type, ticket);
                return ticket;
            }

            public static decimal FreeBay(Ticket ticket, decimal payment)
            {
                Bay bay;
                _usedBays.TryGetValue(ticket.Id, out bay);

                if (bay != null)
                {
                    _usedBays.Remove(ticket.Id);
                    switch (bay.VehicleType)
                    {
                        case VehicleType.Motorcycle:
                            {
                                _smallBays.Push(bay);
                                break;
                            }
                        case VehicleType.Car:
                            {
                                _mediumBays.Push(bay);
                                break;
                            }
                        case VehicleType.Truck:
                            {
                                _largeBays.Push(bay);
                                break;
                            }
                    }
                }

                var change = TicketMachine.ProcessTicketPayment(ticket, payment);
                return change;
            }

            private static void AddToBay(VehicleType type, Ticket ticket)
            {
                switch (type)
                {
                    case VehicleType.Motorcycle:
                    {
                        if (_smallBays.Count <= _smallBayLimit)
                        {
                            var bay = _smallBays.Pop();
                                _usedBays.Add(ticket.Id, bay);
                        }
                        else if (_mediumBays.Count <= _mediumBayLimit)
                        {
                            var bay = _mediumBays.Pop();
                                _usedBays.Add(ticket.Id, bay);
                        }
                        else if (_largeBays.Count <= _largeBayLimit)
                        {
                            var bay = _largeBays.Pop();
                                _usedBays.Add(ticket.Id, bay);
                        }
                        break;
                    }
                    case VehicleType.Car:
                    {
                        if (_mediumBays.Count <= _mediumBayLimit)
                        {
                            var bay = _mediumBays.Pop();
                                _usedBays.Add(ticket.Id, bay);
                        }
                        else if (_mediumBays.Count <= _mediumBayLimit)
                        {
                            var bay = _largeBays.Pop();
                                _usedBays.Add(ticket.Id, bay);
                        }
                        break;
                    }

                    case VehicleType.Truck:
                    {
                        if (_mediumBays.Count <= _mediumBayLimit)
                        {
                            var bay = _largeBays.Pop();
                                _usedBays.Add(ticket.Id, bay);
                        }
                        break;
                    }
                }
            }

            private static VehicleType GetType(IVehicle vehicle)
            {
                if (vehicle is Motorcycle)
                {
                    return VehicleType.Motorcycle;
                }
                else if (vehicle is Car)
                {
                    return VehicleType.Car;
                }
                else
                {
                    return VehicleType.Truck;
                }
            }
        }

        public enum VehicleType
        {
            Truck,
            Car,
            Motorcycle
        }

        public class TicketMachine
        {
            public Ticket PrintTicket()
            {
                var ticket = new Ticket
                {
                    Id = 1  // Autoincrement...
                };
                // Print bay number .etc
                return ticket;
            }

            public decimal ProcessTicketPayment(Ticket ticket, decimal money)
            {
                // Get price and return change, throw if error reading ticket .etc
                return 2.57M;   // Some change amount
            }
        }

        public class Ticket
        {
            public int Id { get; set; }
            // Image, size, .etc
        }

        public class Bay
        {
            public int Id { get; set; }
            public int Level { get; set; }
            public VehicleType VehicleType { get; set; }
        }

        public interface IVehicle
        {
            void Honk();
        }
        public abstract class Vehicle : IVehicle
        {
            public string NumberPlate { get; set; }
            public abstract void Honk();
        }

        public class Motorcycle : Vehicle
        {
            public override void Honk()
            {
                throw new System.NotImplementedException();
            }
        }


        public class Car : Vehicle
        {
            public override void Honk()
            {
                throw new System.NotImplementedException();
            }
        }

        public class Truck : Vehicle
        {
            public override void Honk()
            {
                throw new System.NotImplementedException();
            }
        }

    }
}
