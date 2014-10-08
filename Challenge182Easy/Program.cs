namespace Challenge182Easy
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    class Program
    {
        private const string INPUT_FILE = @"../../Input.txt";

        private static int number_of_columns, column_width, space_width;
        
        public static void Main(string[] args)
        {            
            // Make sure the input file is there. If not, throw an exception.
            if (!File.Exists(INPUT_FILE))
            {
                throw new FileNotFoundException("Input file could not be found: " + INPUT_FILE);
            }

            using (StreamReader stream = new StreamReader(INPUT_FILE))
            {
                // The first line of the input will give us our variables, so let's read that off before the main loop
                string line = stream.ReadLine();
                int.TryParse(line.Split(new char[] { ' ' })[0], out number_of_columns);
                int.TryParse(line.Split(new char[] { ' ' })[1], out column_width);
                int.TryParse(line.Split(new char[] { ' ' })[2], out space_width);

                string all_text = string.Empty;
                while ((line = stream.ReadLine()) != null)
                {
                    all_text += line;
                }

                List<string> big_column = new List<string>();
                while (all_text.Length > column_width)
                {
                    big_column.Add(all_text.Substring(0, column_width));
                    all_text = all_text.Substring(column_width);
                }

                int lines_per_column = (big_column.Count / number_of_columns) + 1;
                List<List<string>> columns = new List<List<string>>();

                for (int c = 0; c < number_of_columns; c++)
                {
                    int offset = c * lines_per_column;
                    columns.Add(big_column.GetRange(0 + offset, lines_per_column));
                }

                using (StreamWriter writer = new StreamWriter(@"../../Output.txt"))
                {
                    line = string.Empty;
                    for (int row = 0; row < columns[0].Count; row++)
	                {
		                for (int c = 0; c < number_of_columns; c++)
                        {
                            line += columns[c][row] + " ";
                        }
	                }

                    
                }
                
            }
        }
    }
}
