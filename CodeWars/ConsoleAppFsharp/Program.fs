open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
     
      
     let rec calcMaxArea (left:int) (right:int) (height:int[]) (max:int) =
         if (left >= right) then max
         else
             let curHeight = Math.Min(height[left], height[right])
             let currentVolume = (right - left) * curHeight
             let curMax = Math.Max(max, currentVolume)
             if (height[left] < height[right]) then calcMaxArea (left + 1) right height curMax
             else calcMaxArea left (right - 1) height curMax
             
     let maxArea(height: int[]) =
         calcMaxArea 0 (height.Length - 1) height 0
         
     let test = maxArea [|1;8;6;2;5;4;8;3;7|]    
     printfn "Hello from F#1"
