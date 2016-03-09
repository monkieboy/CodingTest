module CodingTest.Harness

type SeedValues =
  {
    initialX     : float 
    initialY     : float
    sizeOfSeries : int
    y_const      : float }

let firstNumber x =
  (0.5 * x**2. + 30. * x + 10.) / 25.

let toQuart x =
  let quarted = x * 4.
  let rounded = System.Math.Round(quarted, System.MidpointRounding.AwayFromZero)
  rounded / 4.

let growthRate y firstNum =
  toQuart ((y * 0.02) / 25. / firstNum)

let genSeries grwthRt fstNum len =
  [ yield fstNum
    for i in 1..(len-1) -> 
      grwthRt * (fstNum**(float i)) ]
  |> List.sortByDescending (fun i -> -(i))
  |> List.map toQuart
//  |> Set.ofList // remove dups, shouldn't be required really
//  |> Set.toList

let special1 series =
  series
  |> List.rev
  |> List.skip 2
  |> List.head

let takeClosest x = 
  Seq.map (fun n -> abs(n-x), n)
  >> Seq.sortByDescending (fun (k,v) -> -(k), v)
  >> Seq.head 
  >> snd

let special2 series z (y:float) =
  takeClosest (y / z) series