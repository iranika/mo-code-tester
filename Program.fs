﻿//these are similar to C# using statements
open canopy.runner.classic
open canopy.configuration
open canopy.classic

canopy.configuration.chromeDir <- System.AppContext.BaseDirectory

//start an instance of chrome
start chrome

//this is how you define a test
"モーダル閉じる" &&& fun _ ->
    //this is an F# function body, it's whitespace enforced

    url "https://iranika.github.io/mo-code/index.html" //mo-codeのサイトを開く
    displayed "#modal"  //モーダルが表示されている
    click ".modal-label" //モーダルラベル(右上バツ)をクリック
    notDisplayed "#modal"   //モーダルが非表示になっている

"最初から読む" &&& fun _ ->
    url "https://iranika.github.io/mo-code/index.html" //mo-codeのサイトを開く
    displayed "#modal"  //モーダルが表示されている
    click "最初から読む" //最初から読むをクリック
    notDisplayed "#modal"   //モーダルが非表示になっている
    //対象ページの画像であることをチェックしたいけどいいアイデアが思い浮かばない//
    
"新作から読む" &&& fun _ ->
    url "https://iranika.github.io/mo-code/index.html" //mo-codeのサイトを開く
    displayed "#modal"  //モーダルが表示されている
    click "新作から読む" //新作から読むをクリック
    notDisplayed "#modal"   //モーダルが非表示になっている
    //対象ページの画像であることをチェックしたいけどいいアイデアが思い浮かばない//
    
"ハッシュでページ遷移" &&& fun _ ->
    url "https://iranika.github.io/mo-code/index.html#5" //mo-codeのサイトを開く#5のページ
    notDisplayed "#modal"   //モーダルが非表示になっている(ページ指定の場合はモーダル非表示が仕様)
    //対象ページの画像であることをチェックしたいけどいいアイデアが思い浮かばない//
    url "https://iranika.github.io/mo-code/index.html#latest" //mo-codeのサイトを開く#latestは最後のページを表示する仕様
    notDisplayed "#modal"   //モーダルが非表示になっている(ページ指定の場合はモーダル非表示が仕様)
    //対象ページの画像であることをチェックしたいけどいいアイデアが思い浮かばない//

"スクロールによるオートロード" &&& fun _ ->
    url "https://iranika.github.io/mo-code/index.html" //mo-codeのサイトを開く#5のページ
    //いいアイデアがない//
    
//run all tests
run()

//printfn "press [enter] to exit"
//System.Console.ReadLine() |> ignore

quit()