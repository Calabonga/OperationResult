# OperationResult

OperationResult is an implementation of RFC7807. In other words, it's simple wrapper for result operation for any returned data from backend, where you can add additional information about problem or other things.

"Частичная реализация" стандарта [RFC7807](https://www.rfc-editor.org/rfc/rfc7807), который определяет в документе следующее:

> This document defines a "problem detail" as a way to carry machine-
> readable details of errors in a HTTP response to avoid the need to
> define new error response formats for HTTP APIs.

Суть в том, что если у вас есть API и в нем есть методы отдающие данные, например `Product`, то в результате успешного результата вы должны отдать сам объект `Product`. А вот если по какой-то причине вы не можете отдать конкретный объект (или объекты), тогда вы должные указать по какой причине вы не можете это сделать. Другими словами "детализировать проблему" (problem detail). А как это сделать как раз и описывает стандарт RFC7807.

Почему "Частичная реализация"? Потому что nuget-пакет и, соответственно, потребность в нем появилась задолго до появления стандарта. Постепенно, пакет трансформируется под стандарт, но это может занять некоторое время. Если у вас нет времени ждать, пишите свою реализацию или воспользуйтесь стандартами на платформе ASP.NET Core.

# Репозиторий

[GitHub](https://github.com/Calabonga/OperationResult/)

# Пакеты Nuget

[Nuget OperationResult](https://www.nuget.org/packages/OperationResult/)

[Nuget OperationResultCore](https://www.nuget.org/packages/OperationResultCore/)

# Дополнительно

[Статья в блоге 1](https://www.calabonga.net/blog/post/operationresult-otvet-servera-vsegda-ponyaten-polzovatelyu)

[Статья в блоге 2](https://www.calabonga.net/blog/post/operationresult-kak-rezultat-operacii-zaprosa-na-backend)

[Видео YouTube](https://youtu.be/VAJeYR-YAI4)

