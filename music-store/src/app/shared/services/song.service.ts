import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Song } from '../models/song';

@Injectable({
  providedIn: 'root'
})
export class SongService {
  private readonly apiEndpointBase: string = "https://localhost:44345/api/song";

  constructor(private http: HttpClient) { }

  public getAll(): Observable<Song[]> {
    return this.http.get<Song[]>(this.apiEndpointBase);
  }

  public getByArtist(searchTerm: string): Observable<Song[]> {
    return this.http.get<Song[]>(`${this.apiEndpointBase}/${searchTerm}`);
  }

  public save(song: Song): Observable<Song> {
    return this.http.post<Song>(this.apiEndpointBase, song);
  }

  public delete(id: number): Observable<Song> {
    return this.http.delete<Song>(`${this.apiEndpointBase}/${id}`);
  }
}
