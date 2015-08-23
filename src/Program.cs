namespace TeamBattleField2
{
   using System;

   class BattleField
   {
      private int currentFieldSize;
      private string[,] fieldPositions;
      private int detonatedMines;

      public BattleField(int currentFieldSize)
       {
           this.CurrentFieldSize = currentFieldSize;
           this.FieldPositions = new string[currentFieldSize, currentFieldSize];
           this.DetonatedMines = 0;
       }

       internal string[,] FieldPositions
       {
           get { return this.fieldPositions; }

           // TODO: Implement checks!
           set
           {
               this.fieldPositions = value;
           }
       }

       internal int CurrentFieldSize
       {
           get { return this.currentFieldSize; }

           // TODO: Implement checks!
           set
           {
               this.currentFieldSize = value;
           }
       }

       internal int DetonatedMines
       {
           get { return this.detonatedMines; }

           // TODO: Implement checks!
           set
           {
               this.detonatedMines = value;
           }
       }

       public void GenerateField()
       {
           for (int i = 0; i < currentFieldSize; i++)
           {
               for (int j = 0; j < currentFieldSize; j++)
               {
                   this.fieldPositions[i, j] = " - ";
               }
           }
       }

      public void PositionMines()
      {//tuka ne sym siguren kakvo tochno pravq ama pyk raboti
          int minesDownLimit = Convert.ToInt32(0.15 * this.CurrentFieldSize * this.CurrentFieldSize);
          int minesUpperLimit = Convert.ToInt32(0.30 * this.CurrentFieldSize * this.CurrentFieldSize);

         Random rnd = new Random();

         int minesCount = Convert.ToInt32(rnd.Next(minesDownLimit, minesUpperLimit));
          
          // Unsed:
         // int[,] minesPositions = new int[minesCount, minesCount];
          
        // This should be out of this class
         Console.WriteLine("mines count is: " + minesCount);
          
         for (int i = 0; i < minesCount; i++)
         {
             bool alreadyPositionedMine;

            do {
                int currentMineXCoordinate;
                int currentMineYCoordinate;

                currentMineXCoordinate = Convert.ToInt32(rnd.Next(0, this.CurrentFieldSize - 1));
                currentMineYCoordinate = Convert.ToInt32(rnd.Next(0, this.CurrentFieldSize - 1));

                if (this.FieldPositions[currentMineXCoordinate, currentMineYCoordinate] == " - ")
                {
                    this.FieldPositions[currentMineXCoordinate, currentMineYCoordinate] =
                        " " + Convert.ToString(rnd.Next(1, 6) + " ");
                    alreadyPositionedMine = false;
                }
                else
                {
                    alreadyPositionedMine = true;                    
                }
            } while (alreadyPositionedMine);
         }
      }

      //tuka sa mogyshtite metodi za gyrmejite

       //Checking if entered coordinates are valid
       private bool PrevIsValid(int coord)
       {
           bool result = (coord - 1) >= 0;
           return result;
       }

       private bool NextIsValid(int coord, int size)
       {
           bool result = (coord + 1) < size;
           return result;
       }

      //public void DetonateMine1(int XCoord, int YCoord)
      //{
      //    this.fieldPositions[XCoord, YCoord] = " X ";

      //    if (PrevIsValid(XCoord) && PrevIsValid(YCoord))
      //    {
      //        this.fieldPositions[XCoord - 1, YCoord - 1] = " X ";
      //    }
      //    if (PrevIsValid(XCoord) && NextIsValid(YCoord, currentFieldSize))
      //    {
      //        this.fieldPositions[XCoord - 1, YCoord + 1] = " X ";
      //    }
      //    if (NextIsValid(XCoord, currentFieldSize) && PrevIsValid(YCoord))
      //    {
      //        this.fieldPositions[XCoord + 1, YCoord - 1] = " X ";
      //    }
      //    if (NextIsValid(XCoord, currentFieldSize) && NextIsValid(YCoord, currentFieldSize))
      //    {
      //      this.fieldPositions[XCoord + 1, YCoord + 1] = " X ";
      //    }
      //}

      //public void DetonateMine2(int XCoord, int YCoord)
      //{
      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord - 1] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord - 1] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord - 1] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord + 1] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord + 1] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord + 1] = " X ";
      //}

      //public void DetonateMine3(int XCoord, int YCoord)
      //{
      //   if ((XCoord - 2 >= 0) && (XCoord - 2 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord - 2, YCoord] = " X ";
      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord] = " X ";
      //   if ((XCoord + 2 >= 0) && (XCoord + 2 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord + 2, YCoord] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord - 1] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord + 1] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord + 1] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord - 1] = " X ";

      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord - 2] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord - 1] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord + 1] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord + 2] = " X ";
      //}

      //public void DetonateMine4(int XCoord, int YCoord)
      //{
      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord - 1] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord - 1] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord - 1] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord + 1] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord + 1] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord + 1] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord + 2] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord + 2] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord + 2] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord - 2] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord - 2] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord - 2] = " X ";

      //   if ((XCoord - 2 >= 0) && (XCoord - 2 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 2, YCoord - 1] = " X ";
      //   if ((XCoord - 2 >= 0) && (XCoord - 2 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord - 2, YCoord] = " X ";
      //   if ((XCoord - 2 >= 0) && (XCoord - 2 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 2, YCoord + 1] = " X ";

      //   if ((XCoord + 2 >= 0) && (XCoord + 2 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 2, YCoord - 1] = " X ";
      //   if ((XCoord + 2 >= 0) && (XCoord + 2 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord + 2, YCoord] = " X ";
      //   if ((XCoord + 2 >= 0) && (XCoord + 2 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 2, YCoord + 1] = " X ";
      //}

      //public void DetonateMine5(int XCoord, int YCoord)
      //{
      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord - 1] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord - 1] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord - 1] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord + 1] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord + 1] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord + 1] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord + 2] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord + 2] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord + 2] = " X ";

      //   if ((XCoord - 1 >= 0) && (XCoord - 1 < currentFieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < currentFieldSize))
      //      this.fieldPositions[XCoord - 1, YCoord - 2] = " X ";
      //   if ((XCoord >= 0) && (XCoord < currentFieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < currentFieldSize))
      //      this.fieldPositions[XCoord, YCoord - 2] = " X ";
      //   if ((XCoord + 1 >= 0) && (XCoord + 1 < currentFieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < currentFieldSize))
      //      this.fieldPositions[XCoord + 1, YCoord - 2] = " X ";

      //   if ((XCoord - 2 >= 0) && (XCoord - 2 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 2, YCoord - 1] = " X ";
      //   if ((XCoord - 2 >= 0) && (XCoord - 2 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord - 2, YCoord] = " X ";
      //   if ((XCoord - 2 >= 0) && (XCoord - 2 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord - 2, YCoord + 1] = " X ";

      //   if ((XCoord + 2 >= 0) && (XCoord + 2 < currentFieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 2, YCoord - 1] = " X ";
      //   if ((XCoord + 2 >= 0) && (XCoord + 2 < currentFieldSize) && (YCoord >= 0) && (YCoord < currentFieldSize))
      //      this.fieldPositions[XCoord + 2, YCoord] = " X ";
      //   if ((XCoord + 2 >= 0) && (XCoord + 2 < currentFieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < currentFieldSize))
      //      this.fieldPositions[XCoord + 2, YCoord + 1] = " X ";

      //   if ((XCoord - 2 >= 0) && (XCoord - 2 < currentFieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < currentFieldSize))
      //      this.fieldPositions[XCoord - 2, YCoord - 2] = " X ";
      //   if ((XCoord + 2 >= 0) && (XCoord + 2 < currentFieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < currentFieldSize))
      //      this.fieldPositions[XCoord + 2, YCoord - 2] = " X ";
      //   if ((XCoord - 2 >= 0) && (XCoord - 2 < currentFieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < currentFieldSize))
      //      this.fieldPositions[XCoord - 2, YCoord + 2] = " X ";
      //   if ((XCoord + 2 >= 0) && (XCoord + 2 < currentFieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < currentFieldSize))
      //      this.fieldPositions[XCoord + 2, YCoord + 2] = " X ";
      //}


       //tuka se izbira kva bomba da grymne
      //public void DetonateMine(int XCoord, int YCoord)
      //{
      //   switch (Convert.ToInt32(this.fieldPositions[XCoord, YCoord]))
      //   {
      //      case 1: this.DetonateMine1(XCoord, YCoord);
      //         break;
      //      case 2: this.DetonateMine2(XCoord, YCoord);
      //         break;
      //      case 3: this.DetonateMine3(XCoord, YCoord);
      //         break;
      //      case 4: this.DetonateMine4(XCoord, YCoord);
      //         break;
      //      case 5: this.DetonateMine5(XCoord, YCoord);
      //         break;
      //   }
      //}

      public int CountRemainingMines()
      {
         int count = 0;

         for (int i = 0; i < this.CurrentFieldSize; i++)
         {
             for (int j = 0; i < this.CurrentFieldSize; i++)
            {
               if ((this.FieldPositions[i, j] != " X ") && (this.FieldPositions[i, j] != " - "))
                  count++;
            }
         }

         return count;
      }



     
   }
}