using APBDPro1;

LiquidCon liquidContainer = new LiquidCon(243, 2000, 605, 26000, 1000, true);
GasCon gasContainer = new GasCon(243, 2500, 605, 240, 1000, 1000);
RefrigeratedCon refrigeratedContainer = new RefrigeratedCon(243, 3000, 605, 28000, 1000,"Bananas", -2.0, -1);

LiquidCon liquidContainer2 = new LiquidCon(243, 2000, 605, 26000, 1000, true);
GasCon gasContainer2 = new GasCon(243, 2500, 605, 240, 1000, 1000);
RefrigeratedCon refrigeratedContainer2 = new RefrigeratedCon(243, 3000, 605, 28000, 1000,"Bananas", -2.0, -1);

List<Container> containers = new List<Container>();
containers.Add(liquidContainer2);
containers.Add(gasContainer2);

Ship ship1 = new Ship(20.0, 10, 1000000);
Ship ship2 = new Ship(25.0, 100, 1000);

liquidContainer.Loading(10);
gasContainer.Loading(10);
refrigeratedContainer.Loading(10);

ship1.Load(liquidContainer);
ship1.Load(gasContainer);
ship1.Load(refrigeratedContainer);
ship1.Load(containers);
ship1.Unload(gasContainer);

ship1.Swap(refrigeratedContainer ,ship2);
ship1.Remove(gasContainer);
ship1.Replace("KON-L-1", refrigeratedContainer2);

Console.WriteLine(ship1);
Console.WriteLine(ship2);

