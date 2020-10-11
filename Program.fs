open System

type Suit = Clubs | Diamonds | Hearts | Spades
    (* with *)
    (* member this.FullText = match this with | Spade -> "Spade" | Heart -> "Heart" | Diamond -> "Diamond" | Club -> "Club" *)
    (* member this.Text = match this with | Spade -> 's' | Heart -> 'h' | Diamond -> 'd' | Club -> 'c' *)
    (* member this.Symbol = match this with | Spade -> '♠' | Heart -> '♥' | Diamond -> '♦' | Club -> '♣' *)

type Rank = Ace | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King
(* type Card = { Rank: Rank; Suit : Suit } *)

type Card = Rank * Suit
let suits = [ Hearts ; Spades ; Clubs ; Diamonds ]
let ranks = [ Ace; Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King ]

type Hand = Card list
type Deck = Card list

(* let cardText (rank:Rank, suit:Suit) = sprintf "%c%c" rank.Text suit.Text *)

let shuffle deck =
    let random = new System.Random()
    deck |> List.sortBy (fun x -> random.Next())

// fifteen :: [Card] -> Int
// let fifteen cards | (sum . map cardValue $ cards) == 15 = 2
// fifteen _ = 0

(* let private unshuffledDeck : Card = *)
(*     [ Spade ; Heart ; Diamond ; Club ] *)
(*     |> List.collect (fun suit -> [ King ; Queen ; Jack ; Ten ; Nine ; Eight ; Seven ; Six ; Five ; Four ; Three ; Two ; Ace ] |> List.map (fun rank -> rank, suit)) *)
(*     |> Set.ofList *)

let unshuffledDeck = [for suit in suits do
                         for rank in ranks do
                            yield Card(rank,suit)]

let getRank (card:Card) =
    fst card

let cardValue card =
    match getRank card with
    | Ace -> 1
    | Two -> 2
    | Three -> 3
    | Four -> 4
    | Five -> 5
    | Six -> 6
    | Seven -> 7
    | Eight -> 8
    | Nine -> 9
    | Ten | Jack | Queen | King -> 10

(* let rankToPoints card = *)
(*         match card with *)
(*         | RankCard (rank, _) -> *)
(*             match rank with *)
(*             | Ace -> 1 *)
(*             | Two -> 2 *)
(*             | Three -> 3 *)
(*             | Four -> 4 *)
(*             | Five -> 5 *)
(*             | Six -> 6 *)
(*             | Seven -> 7 *)
(*             | Eight -> 8 *)
(*             | Nine -> 9 *)
(*             | Ten -> 10 *)
(*         | FaceCard (face, _) -> 10 *)

[<EntryPoint>]
let main argv =
    printfn "--- separate ---"
    let shuffledDeck = shuffle unshuffledDeck
    shuffledDeck |> List.iter (printfn "%O ")
    0
