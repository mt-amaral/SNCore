class ChartManager {
    constructor(container, dotNetRef, yMax, dateList) {
        this.container = container;     // Elemento container do gráfico
        this.dotNetRef = dotNetRef;     // Referência para o componente .NET
        this.yMax = yMax;               // Valor máximo do eixo Y
        this.dateList = JSON.parse(dateList).map(date => new Date(date));
        this.initChart();               // Inicializa elementos do gráfico
        this.setupEvents();
        this.setupEvents3();
    }

    initChart() {
        // Configurações básicas do SVG
        this.width = 700;
        this.height = 300;
        this.margin = { top: 20, right: 20, bottom: 30, left: 40 };

        // Cria elemento SVG principal
        this.svg = d3.select(this.container)
            .append("svg")
            .attr("width", this.width)
            .attr("height", this.height);
        
        // Configura escala e eixo X
        this.xScale = d3.scaleUtc()
            .domain(this.dateList)
            .range([this.margin.left, this.width - this.margin.right]);

        this.xAxis = this.svg.append("g")
            .attr("transform", `translate(0,${this.height - this.margin.bottom})`)
            .call(d3.axisBottom(this.xScale));

        // Configura escala e eixo Y
        this.yScale = d3.scaleLinear()
            .domain([0, this.yMax])
            .range([this.height - this.margin.bottom, this.margin.top]);

        this.yAxis = this.svg.append("g")
            .attr("transform", `translate(${this.margin.left},0)`)
            .call(d3.axisLeft(this.yScale));
    }

    setupEvents() {
        // Evento de clique no eixo Y para dobrar o valor
        this.yAxis.on("click", async () => {
            await this.dotNetRef.invokeMethodAsync("OnYMaxChanged", this.yMax * 2);
        });
    }

    setupEvents3() {
        // Evento de clique no eixo Y para dobrar o valor
        this.xAxis.on("click", async () => {
            await this.dotNetRef.invokeMethodAsync("OnYMaxChanged33", this.dateList);
        });
    }

    // Atualiza a escala do eixo Y
    updateYMax(newMax) {
        this.yMax = newMax;
        this.yScale.domain([0, this.yMax]);     // Atualiza domínio
        this.yAxis.call(d3.axisLeft(this.yScale)); // Redesenha eixo
    }

    updateDate(newDateList) {
        // Atualiza a lista de datas
        this.dateList = newDateList;

        // Atualiza o domínio da escala xScale
        this.xScale.domain(this.dateList);
        // Redesenha o eixo xAxis
        this.xAxis// Seleciona o grupo do eixo x
            .call(d3.axisBottom(this.xScale)); // Aplica a nova escala ao eixo
    }

    // Remove o SVG ao destruir
    dispose() {
        d3.select(this.container).selectAll("svg").remove();
    }
}

// Funções de interface para Blazor
export function initializeChart(container, dotNetRef, yMax, dateList) {
    return new ChartManager(container, dotNetRef, yMax, dateList);
}

export function updateYMax(instance, yMax) {
    console.log(yMax, "yMax");
    instance.updateYMax(yMax);
}

export function updateDate(instance, date) {
    console.log(date, "data");
    instance.updateDate(JSON.parse(date).map(date => new Date(date)));
}

export function disposeChart(instance) {
    instance.dispose();
}