# Dokumentasi Game: Cat To The Moon

## 1. Deskripsi
Cat To The Moon adalah **game 2D platformer** bertema kucing yang mengumpulkan ikan untuk menambah score.  
Terdapat **buffs** khusus berupa:  
- **Golden Fish** → meningkatkan kecepatan selama beberapa detik  
- **Flying Fish** → meningkatkan tinggi lompat sementara  

Tujuan game: **mengumpulkan score sebanyak-banyaknya tanpa jatuh ke jurang**.

## 2. Tools
Cat To The Moon menggunakan berbagai macam tools dalam proses pembuatannya:
    1. Unity 6 2D Engine sebagai mesin utama game
    2. Aseprite membuat asset game dalam bentuk pixel art 2D
    3. Remove.bg menghapus background dari png asset
    4. GPT untuk membantu bagian backend
    5. Dreamina digunakan untuk membuat pose asset perframe dengan aset utama karakter dibuat sendiri dengan menggunakan Asepirate, dan untuk membuat frames gerakannya kita menggunakan Dreamina agar lebih efisien secara waktu.
    6. Gemini untuk membuat background utama dari game

## Assets
Terdapat berbagai macam asset yang digunakan pada game Cat To The Moon ini:
    1. Player (Cat): Untuk aset ini dibuat sendiri dengan menggunakan aseprite yang akan digunakan sebagai karakter utama yang dapat di gerakan oleh user
    2. Background Game: Menggunakan Gemini untuk membuat background utama agar lebih efisien
    3. Ground (tanah): Menggunakan free asset dari www.gameart2d.com
    4. Ground (awan): Dibuat dengan menggunakan aseprite untuk ground pada saat mencapai ketinggian tertentu
    5. Fish: Dibuat dengan menggunakan Aseprite yang nantinya dapat di collect oleh player sebagai poin
    6. Sign: Digunakan untuk titik respwan, checkpoint, dan finish dari game. Dibuat dengan menggunakan Asepite
    7. Tree & Bush: Dekorasi game yang tidak interaktif dibuat dengan menggunakan aseprite.

## Animation 
Pada game Cat To The Moon ini ada 3 animasi pada player yaitu:
    1. Idle: posisi diam player yang nantinya player seolah bergerak. Disini kita menggunakan dreamina untuk membuatkan frames dari karakter saat idle.
    2. Walk: posisi berjalan, sama juga menggunakan dreamina untuk membuat framesnya.
    3. Jump: posisi player saat melompat. menggunakan dreamina untum membuat framesnya.

## BackEnd
Pada sisi backend game ini, kami menggunakan C# yaitu:
    1. player.cs: digunakan untuk menentukan aksi apa saja yang bisa dilakukan player.
    2. MusicManager.cs: digunakan untuk menambahkan music pada game, sound effect dan back sound.
    3. CameraFollow.cs: digunakan agar main camera selalu mengikuti posisi dari player.
    4. BackgroundFollow.cs: digunakan agar background selalu menyesuaikan posisi dari main camera.
    5. CameraTransform.cs: digunakan untuk menyesuaikan effect dari background dan camera pada tampilan.
    6. FlyingFish.cs: digunakan untuk menambahkan buff jump ke player agar lompatannya lebih tinggi.
    7. GoldenFish.cs: digunakan untuk menambahkan buff kecepatan berjalan player.
    8. Finish.cs: digunakan untuk papan finish agar menampilkan panel selamat.

## Add Component
    1. Player: RigBody2D, ColliderBox2D, AudioSource, C# script, Tag Player
    2. Ground: TileMapCollider, RigBody2D, CompositeCollider2D, Tag Ground
    3. Fish: CircleCollider2D, Tag Fish
    4. Start Sign: BoxCollider2D, Tag respawn
    5. Checkpoint Sign: BoxCollider2D, Tag CheckPoint
    6. Background: C# script
    7. Main Camera: AudioListener, C# Script