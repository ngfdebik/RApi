# RApi
Данное Api предназначено для игры в крестики нолики.

Чтобы создать игровое поле нужно отправить запрос Post, в случае успеха вам вернётся id созданного поля, иначе ошибка Conflict.

Для того чтобы получить игровое поле в формате JSON, нужно отправить запрос Get указав в ссылке через слеш id  вашей игры(http://ссылка/id).

В полученном файле будет 9 ячеек со значениями CellId от 1 до 9, и созначениями их типа, где 0 = none, 1 = X, 2 = O, а так же id этого поля и тип победителя(такой же как и тип ячейки).

Для того чтобы изменить тип ячейки нужно отправить запрос Patch указав в ссылке id, type = тип ячейки в числовом формате, CellId = id ячейки(https://ссылка/id, type, CellId).

И для того чтобы удалить поле нужно отправить запрос Delete указав в ссылке id(http://ссылка/id).
