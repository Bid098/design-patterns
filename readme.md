Ecco un esercizio che combina l'uso dell'Adapter Pattern e del Decorator Pattern. L'obiettivo dell'esercizio sarà integrare un sistema di gestione di contenuti multimediali, in cui usiamo l'Adapter per standardizzare le interfacce di diversi tipi di media e il Decorator per aggiungere funzionalità dinamicamente a questi media.

### Scenario:
Stai sviluppando un'applicazione di gestione di contenuti multimediali che può riprodurre video e audio. Tuttavia, le classi per video e audio hanno interfacce differenti e il tuo sistema deve poter gestire entrambi tramite una interfaccia unificata. Inoltre, vuoi avere la possibilità di aggiungere funzionalità come il logging dell'attività di riproduzione o l'applicazione di filtri senza modificare le classi originali.

### Parte 1: Adapter Pattern
Definisci una interfaccia comune MediaPlayer che abbia un metodo play().
Crea classi concrete VideoPlayer e AudioPlayer che hanno metodi playVideo() e playAudio() rispettivamente.
Implementa due classi Adapter VideoPlayerAdapter e AudioPlayerAdapter che implementano l'interfaccia MediaPlayer. Ogni adapter tradurrà le chiamate da play() ai metodi specifici di ciascuna classe (playVideo() e playAudio()).
### Parte 2: Decorator Pattern
Definisci una classe base Decorator che implementi l'interfaccia MediaPlayer e abbia un'istanza di MediaPlayer come membro.
Crea classi Decorator specifiche come LoggingMediaPlayer che estende la funzionalità base registrando ogni azione di riproduzione nel sistema di logging e FilterMediaPlayer per applicare filtri audio o video durante la riproduzione.
### Esercizio:
Implementa le classi sopra descritte in Java o un altro linguaggio di programmazione a tua scelta.
Crea un main dove istanzi i player con e senza decorator, dimostrando la flessibilità del sistema.
Verifica il funzionamento aggiungendo diversi decoratori a un oggetto MediaPlayer e facendo riprodurre i contenuti.
Questo esercizio ti permetterà di praticare l'implementazione di design patterns strutturali in un contesto pratico, mostrando come possono essere utilizzati insieme per risolvere problemi di interoperabilità e estensibilità in sistemi software complessi.