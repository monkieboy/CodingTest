module CodingTest.Tests.NumberGenTests

open CodingTest.Harness
open NUnit.Framework
open System

let initialX = 1.
let initialY = 5062.5
let sizeOfSeries = 5
let y_const = 1000. 

[<Test>]
let ``Checking lower boundary for quart rounding should return`` () =
  let expected = 10.75
  let failureMsg = "The rounded value does not match the expected value" 

  let actual = toQuart 10.63

  Assert.AreEqual (expected, actual, failureMsg)

[<Test>]
let ``Checking upper boundary for quart rounding should return`` () =
  let expected = 12.0
  let failureMsg = "The rounded value does not match the expected value"

  let actual = toQuart 12.12

  Assert.AreEqual (expected, actual, failureMsg)


[<Test>]
let ``The firstNumber in part 1 should yield 1•62 when x = 1`` () =
  let expected = 1.62
  let failureMsg = "The firstNumber is not equal to the expected value of 1.62"

  let actual = firstNumber initialX

  Assert.AreEqual ( expected, actual, failureMsg )

[<Test>]
let ``The growthRate in part 1 should yield 2•5 when y = 5062•5`` () =
  let fstNo = firstNumber initialX
  let expected = 2.5
  let tolerance = 2.
  let failureMsg = "The growthRate is not equal to the expected value of 2.5"

  let actual = (growthRate initialY fstNo)

  Assert.AreEqual (expected, actual, tolerance, failureMsg )

[<Test>]
let ``The series in part 1 should contain 5 numbers when the length is limited to 5``() =
  let fstNo = firstNumber initialX
  let growthRate = growthRate initialY fstNo
  let expected = 5
  let failureMsg = "The series does not contain the expected amount of numbers"

  let actual = genSeries growthRate  fstNo sizeOfSeries |> List.length

  Assert.AreEqual (expected, actual, failureMsg)

[<Test>]
let ``The series in part 1 should contain 5 numbers in sequence``() =
  let fstNo = firstNumber initialX
  let growthRate = growthRate initialY fstNo
  let expected = [1.5;4.;6.5;10.75;17.25]
  let failureMsg = "The series does not contain the expected amount of numbers"

  let series = genSeries growthRate  fstNo sizeOfSeries
  let actual = seriesQuartered series

  CollectionAssert.AreEqual (expected, actual, failureMsg)

[<Test>]
let ``In part 2, Number1, the special number should equal 6•5 using the preset initialValues`` () =
  let fstNo = firstNumber initialX
  let growthRate = growthRate initialY fstNo
  let seriesUnrounded = genSeries growthRate  fstNo sizeOfSeries
  let series = seriesQuartered seriesUnrounded
  let expected = 6.5
  let failureMsg = "The special number, Number1 does not equal 6.5"

  let actual = special1 series

  Assert.AreEqual (expected, actual, failureMsg)

[<Test>]
let ``In part 2, Number2, the special number should equal 6•5 using the preset initialValues and x = 160`` () =
  let fstNo = firstNumber initialX
  let growthRate = growthRate initialY fstNo
  let seriesUnrounded = genSeries growthRate  fstNo sizeOfSeries
  let series = seriesQuartered seriesUnrounded
  let expected = 6.5
  let failureMsg = "The special number, Number2 does not equal 6.5"

  let actual = special2 series 160. y_const

  Assert.AreEqual (expected, actual, failureMsg)
