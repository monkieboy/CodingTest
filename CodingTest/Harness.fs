module CodingTest.Harness

open System

let firstNumber x =
  (0.5 * x**2. + 30. * x + 10.) / 25.

let toQuart x =
  let quarted = x * 4.
  let rounded = Math.Round(quarted)
  rounded / 4.

let growthRate y firstNum =
   (y * 0.02) / 25. / firstNum

let genSeries grwthRt fstNum len =
  [ yield fstNum
    for i in 1..(len-1) -> 
      grwthRt * (fstNum**(float i)) ]

let seriesQuartered series =
  series
  |> List.sortByDescending (fun i -> -(i))
  |> List.map toQuart
  |> List.distinct

let special1 series =
  series
  |> List.rev
  |> List.skip 2
  |> List.head

let takeClosest x series =
  series
  |> Seq.map (fun n -> abs(n-x), n)
  |> Seq.sortByDescending (fun (k,v) -> -(k), v)
  |> Seq.head 
  |> snd

let special2 series z (y:float) =
  takeClosest (y / z) series