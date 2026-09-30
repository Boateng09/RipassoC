#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void esercizio_1() {
    int x = 42;
    int *ptr = &x;
    printf(" x: %d\n", x);
    printf("x: %p\n", (void*)&x);
    printf("ptr: %d\n\n", *ptr);
    *ptr = 100;
    printf("Dopo la modifica tramite puntatore:\n");
    printf("Nuovo x: %d\n", x);
}
void scambia_es2(int *a, int *b) {
    int temp = *a;
    *a = *b;
    *b = temp;
}
void esercizio_2() {
    int x = 10, y = 20;
    printf("Prima dello scambio: x = %d, y = %d\n", x, y);
    scambia_es2(&x, &y);
    printf("Dopo lo scambio: x = %d, y = %d\n", x, y);
}
void esercizio_3() {
    float *p = (float*)malloc(sizeof(float));
    if (p == NULL) return;
    printf("Inserisci il numero decimale: ");
    scanf("%f", p);
    *p *= 1.20f;
    printf("Valore inserito aumentato del 20%: %.2f\n", *p);
    free(p);
}
void esercizio_4() {
    int n, somma = 0;
    printf("Quanti numeri vuoi inserire? ");
    scanf("%d", &n);
    int *arr = (int*)malloc(n * sizeof(int));
    if (arr == NULL) return;
    for (int i = 0; i < n; i++) {
        printf("Numero %d: ", i + 1);
        scanf("%d", &arr[i]);
        somma += arr[i];
    }
    printf("Somma totale: %d\n", somma);
    free(arr);
}

void esercizio_5() {
    int arr[5] = {10, 20, 30, 40, 50};
    int *ptr = arr;
    printf("Array: [%d, %d, %d, %d, %d]\n\n", arr[0], arr[1], arr[2], arr[3], arr[4]);
    printf("Elementi dell'array stampati tramite puntatore:\n");
    for (int i = 0; i < 5; i++) {
        printf("Elemento %d: %d\n", i, *(ptr + i));
    }
}

void scambia_es6(int *a, int *b) {
    int temp = *a;
    *a = *b;
    *b = temp;
}
void inverti_es6(int *arr, int n) {
    for (int i = 0; i < n / 2; i++) {
        scambia_es6(&arr[i], &arr[n - 1 - i]);
    }
}
void esercizio_6() {
    int n = 6;
    int *arr = (int*)malloc(n * sizeof(int));
    if (arr == NULL) return;
    for (int i = 0; i < n; i++) arr[i] = i + 1;
    printf("N: %d\nArray originale: ", n);
    for (int i = 0; i < n; i++) printf("%d ", arr[i]);
    printf("\n");
    inverti_es6(arr, n);
    printf("Array invertito: ");
    for (int i = 0; i < n; i++) printf("%d ", arr[i]);
    printf("\n");
    free(arr);
}

char* duplica_stringa_es7(const char *s) {
    int len = strlen(s);
    char *copia = (char*)malloc((len + 1) * sizeof(char));
    if (copia == NULL) return NULL;
    strcpy(copia, s);
    return copia;
}
void esercizio_7() {
    const char *orig = "Esercitazione Puntatori";
    char *copia = duplica_stringa_es7(orig);
    printf("Originale: %s\n", orig);
    printf("Copia: %s\n", copia);
    free(copia);
}

int* trova_massimo_es8(int *array, int dimensione) {
    if (dimensione <= 0) return NULL;
    int *max = array;
    for (int i = 1; i < dimensione; i++) {
        if (*(array + i) > *max) {
            max = array + i;
        }
    }
    return max;
}
void esercizio_8() {
    int arr[] = {8, 2, 7, 9, 5};
    int dim = 5;
    printf("Array: [8, 2, 7, 9, 5]\n\n");
    int *pmax = trova_massimo_es8(arr, dim);
    printf("Massimo: %d\n", *pmax);
    printf("Posizione (indice): %ld\n", pmax - arr);
}

void esercizio_9() {
    int n;
    printf("Quante parole vuoi inserire? ");
    scanf("%d", &n);
    char **parole = (char**)malloc(n * sizeof(char*));
    if (parole == NULL) return;
    char buffer[100];
    for (int i = 0; i < n; i++) {
        printf("Parola %d: ", i + 1);
        scanf("%s", buffer);
        parole[i] = (char*)malloc((strlen(buffer) + 1) * sizeof(char));
        strcpy(parole[i], buffer);
    }
    printf("\nParole in ordine inverso:\n");
    for (int i = n - 1; i >= 0; i--) {
        printf("%s\n", parole[i]);
    }
    for (int i = 0; i < n; i++) {
        free(parole[i]);
    }
    free(parole);
}

void esercizio_10() {
    int cap = 2, count = 0, val;
    int *arr = (int*)malloc(cap * sizeof(int));
    if (arr == NULL) return;
    printf("Inserisci numeri (0 per terminare):\n");
    while (1) {
        scanf("%d", &val);
        if (val == 0) break;
        if (count >= cap) {
            cap *= 2;
            printf("(Espansione a %d elementi)\n", cap);
            int *temp = (int*)realloc(arr, cap * sizeof(int));
            if (temp == NULL) { free(arr); return; }
            arr = temp;
        }
        arr[count++] = val;
    }
    printf("\nNumeri inseriti:\n");
    for (int i = 0; i < count; i++) {
        printf("%d ", arr[i]);
    }
    printf("\n");
    free(arr);
}

int* filtra_pari_es11(int *input, int dim, int *nuova_dim) {
    int count = 0;
    for (int i = 0; i < dim; i++) {
        if (input[i] % 2 == 0) count++;
    }
    *nuova_dim = count;
    int *ris = (int*)malloc(count * sizeof(int));
    if (ris == NULL) return NULL;
    int idx = 0;
    for (int i = 0; i < dim; i++) {
        if (input[i] % 2 == 0) {
            ris[idx++] = input[i];
        }
    }
    return ris;
}
void esercizio_11() {
    int input[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    int dim = 10, nuova_dim = 0;
    printf("Input: 1 2 3 4 5 6 7 8 9 10\n");
    int *pari = filtra_pari_es11(input, dim, &nuova_dim);
    printf("Pari trovati (%d): ", nuova_dim);
    for (int i = 0; i < nuova_dim; i++) {
        printf("%d ", pari[i]);
    }
    printf("\n");
    free(pari);
}

void esercizio_12() {
    int r = 3, c = 4;
    printf("Creazione matrice %d x %d\n\n", r, c);
    int **mat = (int**)malloc(r * sizeof(int*));
    for (int i = 0; i < r; i++) {
        mat[i] = (int*)malloc(c * sizeof(int));
    }
    int val = 11;
    for (int i = 0; i < r; i++) {
        for (int j = 0; j < c; j++) {
            mat[i][j] = val + j;
        }
        val += 10;
    }
    printf("Matrice:\n");
    for (int i = 0; i < r; i++) {
        for (int j = 0; j < c; j++) {
            printf("%-8d ", mat[i][j]);
        }
        printf("\n");
    }
    printf("\n");
    for (int i = 0; i < r; i++) {
        int somma = 0;
        for (int j = 0; j < c; j++) {
            somma += mat[i][j];
        }
        printf("Somma riga %d: %d\n", i, somma);
    }
    for (int i = 0; i < r; i++) {
        free(mat[i]);
    }
    free(mat);
}

void esercizio_13() {
    long long n = 0x1122334455667788LL;
    printf("Intero long long: 0x%llx\n", n);
    printf("Rappresentazione in memoria (byte per byte):\n");
    unsigned char *p = (unsigned char*)&n;
    for (int i = 0; i < sizeof(long long); i++) {
        printf("Byte %d: %02x ad indirizzo %p\n", i, p[i], (void*)&p[i]);
    }
}

char* concatena_es14(const char *s1, const char *s2) {
    int len1 = strlen(s1);
    int len2 = strlen(s2);
    char *res = (char*)malloc((len1 + len2 + 1) * sizeof(char));
    if (res == NULL) return NULL;
    char *ptr = res;
    while (*s1) {
        *ptr++ = *s1++;
    }
    while (*s2) {
        *ptr++ = *s2++;
    }
    *ptr = '\0';
    return res;
}
void esercizio_14() {
    const char *s1 = "Puntatori";
    const char *s2 = " e Malloc";
    printf("Stringa 1: %s\n", s1);
    printf("Stringa 2: %s\n", s2);
    char *ris = concatena_es14(s1, s2);
    printf("Risultato: %s\n", ris);
    free(ris);
}

void scambia_es15(float *a, float *b) {
    float temp = *a;
    *a = *b;
    *b = temp;
}
void bubble_sort_es15(float *arr, int n) {
    for (int i = 0; i < n - 1; i++) {
        for (int j = 0; j < n - i - 1; j++) {
            if (*(arr + j) > *(arr + j + 1)) {
                scambia_es15(arr + j, arr + j + 1);
            }
        }
    }
}
void esercizio_15() {
    int n = 5;
    float *arr = (float*)malloc(n * sizeof(float));
    if (arr == NULL) return;
    float temp_vals[] = {45.5f, 12.3f, 67.8f, 2.1f, 33.4f};
    for (int i = 0; i < n; i++) {
        *(arr + i) = temp_vals[i];
    }
    printf("Array originale: ");
    for (int i = 0; i < n; i++) {
        printf("%.1f ", *(arr + i));
    }
    printf("\n");
    bubble_sort_es15(arr, n);
    printf("Array ordinato: ");
    for (int i = 0; i < n; i++) {
        printf("%.1f ", *(arr + i));
    }
    printf("\n");
    free(arr);
}

int main() {
    int scelta;
    do {
        printf(" SELEZIONA L'ESERCIZIO DA ESEGUIRE (1-15)\n");
        printf(" Esci\n");
        printf("Scelta: ");
        if (scanf("%d", &scelta) != 1) break;

        printf("\n--- ESECUZIONE ESERCIZIO %d ---\n\n", scelta);
        switch (scelta) {
            case 1: esercizio_1(); break;
            case 2: esercizio_2(); break;
            case 3: esercizio_3(); break;
            case 4: esercizio_4(); break;
            case 5: esercizio_5(); break;
            case 6: esercizio_6(); break;
            case 7: esercizio_7(); break;
            case 8: esercizio_8(); break;
            case 9: esercizio_9(); break;
            case 10: esercizio_10(); break;
            case 11: esercizio_11(); break;
            case 12: esercizio_12(); break;
            case 13: esercizio_13(); break;
            case 14: esercizio_14(); break;
            case 15: esercizio_15(); break;
            case 0: printf("Uscita in corso...\n"); break;
            default: printf("Scelta non accetabile!\n");
        }
        printf("\n");
    } while (scelta != 0);

    return 0;
}