import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort } from '@angular/material';

import { SongService } from 'src/app/shared/services/song.service';
import { Song } from 'src/app/shared/models/song';

@Component({
  selector: 'app-song-table',
  templateUrl: './song-table.component.html',
  styleUrls: ['./song-table.component.css']
})
export class SongTableComponent implements OnInit {
  public dataSource: MatTableDataSource<Song>;
  public displayedColumns: string[] = ['title', 'artist', 'genre', 'dateAdded', 'delete'];

  @ViewChild(MatSort) sort: MatSort;

  constructor(private songService: SongService) { }

  ngOnInit() {
    this.getSongs();
  }

  
  public applyFilter(searchTerm: string) {
    this.getFilteredSongs(searchTerm);
  }

  public delete(id: number){
    this.songService.delete(id).subscribe(
      () => this.getSongs()
    );
  }

  private getSongs() {
    this.songService.getAll().subscribe(
      (data: Song[]) => this.reloadDataSource(data)
    );
  }

  private getFilteredSongs(searchTerm: string) {
    this.songService.getByArtist(searchTerm).subscribe(
      (data: Song[]) => this.reloadDataSource(data),
      () => this.reloadDataSource([])
    );
  }


  private reloadDataSource(data: Song[]) {
    this.dataSource = new MatTableDataSource<Song>(data);
    this.dataSource.sort = this.sort;
  }
}
