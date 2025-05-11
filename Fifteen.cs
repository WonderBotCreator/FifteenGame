public class Fifteen
{
    int size = 0;
     int[,] numBlock = new int[4, 4];
    int currentRow;
    int currentCol;
     string playerInput;

    public void Run()
    {
        GetInputSize();
        GenerateNumber();
        ShowNumBlock();

        while(!IsComplete())
        {
            GetUserInput();
            ShowNumBlock();
        }

        Console.WriteLine("Finish!");
    }

    void GetInputSize()
    {
         Console.Write("Input Block size between 3 and 5: ");
        size = int.Parse(Console.ReadLine());

        if(size >= 3 && size <= 5)
        {
            numBlock = new int[size,size];
            return;
        }
        else
        {
            GetInputSize();
        }

        
    }

    void GenerateNumber()
    {
        List<int> nums = new List<int>();

        for(int i = 0;i < size*size;i++)
        {
            nums.Add(i);
        }

        Random rnd = new Random();


        for(int i = 0;i< size;i++)
        {
            for(int j = 0;j< size;j++)
            {
                int randomNum  = rnd.Next(0, nums.Count);

                numBlock[i,j] = nums[randomNum];

                if(numBlock[i,j] == 0)
                {
                    currentRow = i;
                    currentCol = j;
                }

                nums.RemoveAt(randomNum);
            }
        }
    }


    void ShowNumBlock()
    {
        for(int i = 0; i< size;i++)
        {
            for(int j = 0;j< size;j++)
            {
                if(numBlock[i,j] < 10)
                {
                    Console.Write(" "+numBlock[i,j]+ " ");
                }
                else
                {
                    Console.Write(numBlock[i,j]+ " ");
                }
                
            }
            Console.WriteLine();
        }
    }

    void GetUserInput()
    {
         Console.WriteLine("Current position: "+(currentRow+1)+","+(currentCol+1));
        Console.Write("Player input: ");
        playerInput = Console.ReadLine();

        SwapNumber(playerInput);
    }

    void SwapNumber(string input)
    {
        switch(input)
        {
            case "up": 
            
            if(currentRow < size-1)
            {
                numBlock[currentRow, currentCol] = numBlock[currentRow+1, currentCol];
                numBlock[currentRow+1, currentCol] = 0;

                UpdateCurrentPosition(currentRow+1, currentCol);
            }
            
            
            break;
            case "down": 
            
            if(currentRow > 0)
            {
                numBlock[currentRow, currentCol] = numBlock[currentRow-1, currentCol];
                numBlock[currentRow-1, currentCol] = 0;

                UpdateCurrentPosition(currentRow-1, currentCol);
            }
            
            break;
            case "left": 
            
            if(currentCol < size-1)
            {
                numBlock[currentRow, currentCol] = numBlock[currentRow, currentCol+1];
                numBlock[currentRow, currentCol+1] = 0;

                UpdateCurrentPosition(currentRow, currentCol+1);
            }
            
            
            break;
            case "right":
            
            if(currentCol > 0)
            {
                numBlock[currentRow, currentCol] = numBlock[currentRow, currentCol-1];
                numBlock[currentRow, currentCol-1] = 0;

                UpdateCurrentPosition(currentRow, currentCol-1);
            }
            
            break;

            default: break;
        }
    }

    void UpdateCurrentPosition(int row, int col)
    {
        currentRow = row;
        currentCol = col;
    }

    bool IsComplete()
    {
        int num = 1;
        for(int i = 0;i< size;i++)
        {
            for(int j = 0;j< size;j++)
            {
                if(num == size*size)
                {
                    return true;
                }

                if(numBlock[i,j] != num)
                {
                    return false;
                }
                else
                {
                    num++;
                }
            }
        }

        return true;
    }
}