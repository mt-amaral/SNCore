class ChartManager {
    constructor(container, dotNetRef, yMax) {
        this.container = container;
        this.dotNetRef = dotNetRef;
        this.yMax = yMax;
        this.initChart();
        this.setupEvents();
    }

    initChart() {
        // Configuração inicial do gráfico
        this.width = 500;
        this.height = 300;
        this.margin = { top: 20, right: 20, bottom: 30, left: 40 };

        this.svg = d3.select(this.container)
            .append("svg")
            .attr("width", this.width)
            .attr("height", this.height);

        // Eixo X
        this.xScale = d3.scaleUtc()
            .domain([new Date("2023-01-01"), new Date("2024-01-01")])
            .range([this.margin.left, this.width - this.margin.right]);

        this.svg.append("g")
            .attr("transform", `translate(0,${this.height - this.margin.bottom})`)
            .call(d3.axisBottom(this.xScale));

        // Eixo Y
        this.yScale = d3.scaleLinear()
            .domain([0, this.yMax])
            .range([this.height - this.margin.bottom, this.margin.top]);

        this.yAxis = this.svg.append("g")
            .attr("transform", `translate(${this.margin.left},0)`)
            .call(d3.axisLeft(this.yScale));
    }

    setupEvents() {
        // Exemplo: Evento de clique no eixo Y
        this.yAxis.on("click", async () => {
            await this.dotNetRef.invokeMethodAsync("OnYMaxChanged", this.yMax * 2);
        });
    }

    updateYMax(newMax) {
        this.yMax = newMax;
        this.yScale.domain([0, this.yMax]);
        this.yAxis.call(d3.axisLeft(this.yScale));
    }

    dispose() {
        d3.select(this.container).selectAll("svg").remove();
    }
}

export function initializeChart(container, dotNetRef, yMax) {
    return new ChartManager(container, dotNetRef, yMax);
}

export function updateYMax(instance, yMax) {
    instance.updateYMax(yMax);
}

export function disposeChart(instance) {
    instance.dispose();
}