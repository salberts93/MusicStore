import { Genre } from '../enums/genre.enum';

export class Song {
    id: number;
    title: string;
    artist: string;
    genre: Genre;
    dateAdded: Date;
}
