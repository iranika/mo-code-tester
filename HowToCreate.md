# mo-code-tester

## tl; dr

自作WEBアプリ[みちくさびゅあー](https://iranika.github.io/mo-code/)をWebDriverで自動テスト.
F#のことが気になって調べてみたらcanopyというテストフレームワークが想像以上に手に馴染んだ.

## 前提条件

.NET Core 2.2のSDKとランタイムのインストール.

https://dotnet.microsoft.com/download/dotnet-core/2.2


## プロジェクトの作成

https://lefthandedgoat.github.io/canopy/  
上記のcanopy公式サイトとだいたい同じですが,dotnet CLIでやる手順を追って説明します.  
  
まずはプロジェクトを作成します。  
今回は自作WEBアプリ[みちくさびゅあー](https://iranika.github.io/mo-code/)のテスト用

``` sh
dotnet new console -lang F# -o mo-code-tester
cd mo-code-tester
```

パッケージをプロジェクトに追加します.

``` sh
dotnet add package canopy --version 2.1.0
dotnet add package Selenium.WebDriver.ChromeDriver
```

## コードの記述

Program.fsにコードを記述します.
canopyの詳細な使い方は公式サイトを参照してください.
主に下記を読んでいれば分かるかと.個人的感想ですがすごく読みやすいです.
[Action](http://lefthandedgoat.github.io/canopy/actions.html)
[Assertions](http://lefthandedgoat.github.io/canopy/assertions.html)
[Test](http://lefthandedgoat.github.io/canopy/testing.html)

``` fs
//these are similar to C# using statements
open canopy.runner.classic
open canopy.configuration
open canopy.classic

canopy.configuration.chromeDir <- System.AppContext.BaseDirectory

//start an instance of chrome
start chrome

//this is how you define a test
"モーダルチェックテスト" &&& fun _ ->
    //this is an F# function body, it's whitespace enforced

    url "https://iranika.github.io/mo-code/index.html" //mo-codeのサイトを開く
    displayed "#modal"  //モーダルが表示されている
    click ".modal-label" //モーダルラベル(右上バツ)をクリック
    notDisplayed "#modal"   //モーダルが非表示になっている

    url "https://iranika.github.io/mo-code/index.html" //mo-codeのサイトを開く
    displayed "#modal"  //モーダルが表示されている
    click "最初から読む" //最初から読むをクリック
    notDisplayed "#modal"   //モーダルが非表示になっている
    
    url "https://iranika.github.io/mo-code/index.html" //mo-codeのサイトを開く
    displayed "#modal"  //モーダルが表示されている
    click "新作から読む" //新作から読むをクリック
    notDisplayed "#modal"   //モーダルが非表示になっている

    url "https://iranika.github.io/mo-code/index.html#5" //mo-codeのサイトを開く#5のページ
    notDisplayed "#modal"   //モーダルが非表示になっている(ページ指定の場合はモーダル非表示が仕様)


//run all tests and quit
run()
quit()
```

## 実行

``` sh
dotnet run
```

Chromeが立ち上がって,テストが実行されます.
今回はChromeのWebDriverを使っているので,実行環境にChromeのインストールが必要です.

## 感想

書いていてストレスが少なかったです.そんなに書く必要が無いから.
ちなみに .NET Core 2.2は自己展開型でpublishできるので, 以下のコマンドでlinux向けに展開できるのも便利.

``` sh
dotnet publish -c Release -r linux-x64 --self-contained true
```



