# Foto_Budka_Modeli

## Projekt zawiera gotową aplikacje fotobudki modeli .obj.
## W katalogu Jan_Mazurek_zadanie_Data znajdują się dwa katalogi:
- Input
- Output

W pierwszym należy wgrać pliki .obj i opcjonalnie .mtl.

W drugim zapisywane są screenshoty.
## Teraz, gdy uruchomi się aplikacje, można obejrzeć wgrane modele oraz robić zdjęcia które są zapisywane w folderze Output.


Dodatkowa funkcjonalność:
- W przypadku braku plików w folderze Input, przyciski GUI zostaną zablokowane
- W przypadku usunięcia któregoś z plików .obj w trakcie działania programu, zostanie wyświetlony stosowny komunikat.
- GUI znika na krótką chwile w trakcie tworzenia zdjęcia tak, aby był na nim tylko obiekt.
- W przypadku braku folderów Input oraz Output, zostaną one utworzone w trakcie włączenia aplikacji.

Sterowanie odbywa się wyłącznie za pomocą myszki:
- Obrót modelu: przytrzymać lewy przycisk myszy i poruszyć nią.
- Przybliżenie lub oddalenie: scroll myszy.

Skrypt do wczytywania plików .obj i .mtl używa bibliotek z https://assetstore.unity.com/packages/tools/modeling/runtime-obj-importer-49547 .

## Działającą aplikacje można pobrać ze strony: https://github.com/Janeeczek/Foto_Budka_Modeli/releases/tag/1.0.0

