import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Genre } from 'src/app/shared/enums/genre.enum';
import { SongService } from 'src/app/shared/services/song.service';
import { Song } from 'src/app/shared/models/song';

@Component({
  selector: 'app-song-form',
  templateUrl: './song-form.component.html',
  styleUrls: ['./song-form.component.css']
})
export class SongFormComponent implements OnInit {
  public genres = ["Pop", "Rock", "Punk", "Metal", "Classic", "Hiphop", "Country"];

  public artist: string;
  public title: string;
  public selectedGenre: Genre;
  constructor(private songService: SongService) { }

  ngOnInit() {
  }

  public isFormFilled(): boolean {
    if (this.artist && this.title && this.selectedGenre) {
      return true;
    }
    return false;
  }

  public submit() {
    let song = new Song();
    song.artist = this.artist;
    song.title = this.title;
    song.genre = this.selectedGenre;
    song.dateAdded = new Date();
    this.songService.save(song).subscribe();
  }
}
