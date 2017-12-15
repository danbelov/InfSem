open System

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

type Item = 
    { 
      id: Guid
      Name: string
      Weight: float
      Value: float 
    }

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
