export interface PagedModel<T>{
    pageSize: number;
    currentPage: number;
    totalCount: number;
    totalPages: number;
    items: T[];
}