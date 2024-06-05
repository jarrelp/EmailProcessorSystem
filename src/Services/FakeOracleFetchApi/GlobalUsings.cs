global using Dapr;
global using Dapr.Client;
global using Dapr.Extensions.Configuration;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using EventBus;
global using EventBus.Abstractions;
global using EventBus.Events;
global using FakeOracleFetchApi;
global using FakeOracleFetchApi.Model;
global using FakeOracleFetchApi.Model.EmailTemplates;
global using FakeOracleFetchApi.Infrastructure;
global using FakeOracleFetchApi.Infrastructure.EntityConfigurations;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Hosting;
global using Microsoft.OpenApi.Models;
global using Polly;

