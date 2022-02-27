# デプロイ方法
`AppRunner.AspNetCore6.HelloWorld`フォルダに移動し、下記のコマンドを実行します。

1. CDK 生成

    ```
    dotnet aws deployment-project generate
    ```

    Choose deployment option(recommended default:1) `2`を選択します。


    AppRunner.AspNetCore6.HelloWorld.Deployment プロジェクトが作成されます。

1. デプロイ

    ```
    dotnet aws deploy --apply aws-deployments.json
    ```

    CLIからの問い合わせはすべてEnterキーを押します。


# 削除方法

下記のコマンドを実行

```
dotnet aws delete-deployment AppRunnerAspNetCore6HelloWorld
```
