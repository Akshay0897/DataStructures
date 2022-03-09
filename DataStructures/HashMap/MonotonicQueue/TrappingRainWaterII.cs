using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///*
//Basic physics:
//Unlike bricks, water flows to wherever it could. 
//i.e we can't have the follwoing config made with water, but can do it with bricks
//000
//010
//000
//In the case above, if the "1" is built with water, that water can't stay. It needs to be spilled!

//2 steps Algorithm: 
//1. Since we know how to trap rain water in 1d, we can just transfor this 2D problem into 2 1D problems
//    we go row by row, to calculate each spot's water
//    we go column by column, to calculate each spot's water

//2. Then, here comes the meat,
//    For every spot that gets wet, from either row or column calculation, the water can possibly spill.
//    We need to check the water height aganist it's 4 neighbors. 
//        If the water height is taller than any one of its 4 neightbors, we need to spill the extra water.
//        If we spill any water from any slot, then its 4 neightbors needs to check themselves again.
//            For example, if we spill some water in the current slot b/c its bottm neighbor's height, current slot's top neighbor's height might need to be updated again.
//        we keep checking until there is no water to be spilled.
//*/


//public class Solution
//{
//    public int trapRainWater(int[][] heightMap)
//    {
//        /*FIRST STEP*/
//        if (heightMap.length == 0) return 0;
//        int[][] wetMap = new int[heightMap.length][heightMap[0].length];
//        int sum = 0;
//        /*row by row*/
//        for (int i = 1; i < wetMap.length - 1; i++)
//        {
//            wetMap[i] = calculate(heightMap[i]);
//        }
//        /*column by column*/
//        for (int i = 1; i < heightMap[0].length - 1; i++)
//        {
//            int[] col = new int[heightMap.length];
//            for (int j = 0; j < heightMap.length; j++)
//            {
//                col[j] = heightMap[j][i];
//            }
//            int[] colResult = calculate(col);
//            /*update the wetMap to be the bigger value between row and col, later we can spill, don't worry*/
//            for (int j = 0; j < heightMap.length; j++)
//            {
//                wetMap[j][i] = Math.max(colResult[j], wetMap[j][i]);
//                sum += wetMap[j][i];
//            }
//        }
//        /*SECOND STEP*/
//        boolean spillWater = true;
//        int[] rowOffset = { -1, 1, 0, 0 };
//        int[] colOffset = { 0, 0, 1, -1 };
//        while (spillWater)
//        {
//            spillWater = false;
//            for (int i = 1; i < heightMap.length - 1; i++)
//            {
//                for (int j = 1; j < heightMap[0].length - 1; j++)
//                {
//                    /*If this slot has ever gotten wet, exammine its 4 neightbors*/
//                    if (wetMap[i][j] != 0)
//                    {
//                        for (int m = 0; m < 4; m++)
//                        {
//                            int neighborRow = i + rowOffset[m];
//                            int neighborCol = j + colOffset[m];
//                            int currentHeight = wetMap[i][j] + heightMap[i][j];
//                            int neighborHeight = wetMap[neighborRow][neighborCol] +
//                                                              heightMap[neighborRow][neighborCol];
//                            if (currentHeight > neighborHeight)
//                            {
//                                int spilledWater = currentHeight - Math.max(neighborHeight, heightMap[i][j]);
//                                wetMap[i][j] = Math.max(0, wetMap[i][j] - spilledWater);
//                                sum -= spilledWater;
//                                spillWater = true;
//                            }
//                        }
//                    }
//                }
//            }
//        }
//        return sum;
//    }

//    /*Nothing interesting here, the same function for trapping water 1*/
//    private int[] calculate(int[] height)
//    {
//        int[] result = new int[height.length];
//        Stack<Integer> s = new Stack<Integer>();
//        int index = 0;
//        while (index < height.length)
//        {
//            if (s.isEmpty() || height[index] <= height[s.peek()])
//            {
//                s.push(index++);
//            }
//            else
//            {
//                int bottom = s.pop();
//                if (s.size() != 0)
//                {
//                    for (int i = s.peek() + 1; i < index; i++)
//                    {
//                        result[i] += (Math.min(height[s.peek()], height[index]) - height[bottom]);
//                    }
//                }
//            }
//        }
//        return result;
//    }

//}

namespace DataStructures.HashMap.MonotonicQueue
{
    public static class TrappingRainWaterII
    {
        public static int TrapRainWater(int[][] heightMap)
        {

            return 0;
        }
    }
}
