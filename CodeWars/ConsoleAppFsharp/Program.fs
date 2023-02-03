open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =
     
     let rotateString (s1:string) (s2:string) =
        
         if (s1.Length <> s2.Length) then false
         else
             let firstChar = s1[0]
             let firstCharPosInS2 = s2.IndexOf firstChar
             let conv = s2.Substring (firstCharPosInS2, (s2.Length - firstCharPosInS2)) + s2.Substring (0, firstCharPosInS2)
             s1 = conv
         
     
     rotateString "abcde" "cdeab" |> ignore    
     printfn "Hello from F#1"
