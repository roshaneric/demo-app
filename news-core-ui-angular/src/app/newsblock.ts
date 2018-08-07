export class NewsBlock {
    id = 0;
    title = '';
    contents: NewsContent[];

    constructor() {
        this.contents = [];
        this.contents.push(new NewsContent());
    }
}

export class NewsContent {
    detail = '';
}
